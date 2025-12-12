using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace WingetRepoBrowserCore;

public static class GitHelpers
{
	private static string? FindRepoRoot(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}
		string? discovered = Repository.Discover(path);
		if (string.IsNullOrEmpty(discovered))
		{
			return null;
		}
		return Path.GetFullPath(Path.Combine(discovered, ".."));
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
				return new RepoCommitInfo() { ErrorMessage= "invalid repoPath" };
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

			return new RepoCommitInfo { Local = localInfo, Remote = remoteInfo, RepositoryRootPath=root };
		}
		catch(Exception ex)
		{
			return new RepoCommitInfo() { ErrorMessage = "GetRepoCommitInfo exception: "+ ex.Message };
		}
	}
}
