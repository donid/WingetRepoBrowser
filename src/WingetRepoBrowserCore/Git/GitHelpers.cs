using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WingetRepoBrowserCore;

public static class GitHelpers
{
	public static string? FindRepoRoot(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}

		string? discoveredDotGitFolder = Repository.Discover(path);
		if (string.IsNullOrEmpty(discoveredDotGitFolder))
		{
			return null;
		}
		
		string repoRootPath = Path.Combine(discoveredDotGitFolder, ".."); // is this the same as "Path.GetDirectoryName(discoveredDotGitFolder)" ?
		return Path.GetFullPath(repoRootPath);
	}

	public static Task<RepoCommitInfo> GetRepoCommitInfoAsync(string repoPath)
	{
		return Task.Run(() =>
		{
			return GetRepoCommitInfo(repoPath);
		});
	}

	static RepoCommitInfo GetRepoCommitInfo(string repoPath)
	{
		try
		{
			string? root = FindRepoRoot(repoPath);
			if (root == null || !Repository.IsValid(root))
			{
				return new RepoCommitInfo() { ErrorMessage = "invalid repoPath" };
			}

			using var repo = new Repository(root);

			Commit? localCommit = repo.Head?.Tip ?? repo.Commits.FirstOrDefault();
			CommitInfo? localInfo = null;
			if (localCommit != null)
			{
				localInfo = new CommitInfo
				{
					Sha = localCommit.Sha,
					Date = localCommit.Author.When,
					Message = localCommit.MessageShort ?? ""
				};
			}

			CommitInfo? remoteInfo = null;
			Remote? remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == "origin") ?? repo.Network.Remotes.FirstOrDefault();
			if (remote != null)
			{
				Branch? remoteBranch = repo.Branches.FirstOrDefault(b => b.IsRemote && (b.FriendlyName.EndsWith("/main") || b.FriendlyName.EndsWith("/master")));
				if (remoteBranch == null && repo.Head != null)
				{
					Branch tracked = repo.Head.TrackedBranch;
					if (tracked != null && tracked.IsRemote)
					{
						remoteBranch = tracked;
					}
				}

				if (remoteBranch?.Tip != null)
				{
					Commit tip = remoteBranch.Tip;
					remoteInfo = new CommitInfo
					{
						Sha = tip.Sha,
						Date = tip.Author.When,
						Message = tip.MessageShort ?? ""
					};
				}
			}

			return new RepoCommitInfo { Local = localInfo, Remote = remoteInfo, RepositoryRootPath = root };
		}
		catch (Exception ex)
		{
			return new RepoCommitInfo() { ErrorMessage = "GetRepoCommitInfo exception: " + ex.Message };
		}
	}


	/// <summary>
	/// Returns a set of directories (absolute paths) that contain .yaml files added/modified/renamed/copied
	/// in commits since <paramref name="sinceUtc"/>.
	/// If the path is not a git repository, an empty collection is returned.
	/// </summary>
	public static IEnumerable<string> GetChangedYamlDirectories(string repoRoot, DateTime sinceDate)
	{
		if (string.IsNullOrWhiteSpace(repoRoot) || !Directory.Exists(repoRoot))
		{
			return Array.Empty<string>();
		}

		if (repoRoot == null || !Directory.Exists(Path.Combine(repoRoot, ".git")))
		{
			// Not a git repository
			return Array.Empty<string>();
		}

		var relativeDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		try
		{
			using (var repo = new Repository(repoRoot))
			{
				var filter = new CommitFilter { SortBy = CommitSortStrategies.Time };

				var filteredCommits = repo.Commits.QueryBy(filter).TakeWhile(commit => commit.Committer.When >= sinceDate).ToList();
				if (filteredCommits.Count<=2)
				{
					//todo print log message
					return Array.Empty<string>();
				}
				Commit oldestCommit = filteredCommits.Last();
				Commit newestCommit = filteredCommits.First();

				TreeChanges changes = repo.Diff.Compare<TreeChanges>(oldestCommit!.Tree, newestCommit!.Tree);
				AddChangedDirs(repoRoot, relativeDirs, changes);
			}

			return relativeDirs.Select(dir=>MakeDirAbsolute(repoRoot,dir));
		}
		catch
		{
			// On any error return empty so caller can fall back
			return Array.Empty<string>();
		}

	}

	private static string MakeDirAbsolute(string repoRoot, string relativeDir)
	{
		string absoluteDir = Path.Combine(repoRoot, relativeDir.Replace('/', Path.DirectorySeparatorChar));
		return absoluteDir;
	}

	private static void AddChangedDirs(string repoRoot, HashSet<string> dirs, TreeChanges changes)
	{
		foreach (var change in changes)
		{
			if (!change.Path.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}

			if (change.Status == ChangeKind.Added
				|| change.Status == ChangeKind.Modified
				|| change.Status == ChangeKind.Renamed
				|| change.Status == ChangeKind.Copied)
			{
				string? relativeDir = Path.GetDirectoryName(change.Path);
				if (relativeDir != null)
				{
					dirs.Add(relativeDir);
				}
			}
		}
	}

}