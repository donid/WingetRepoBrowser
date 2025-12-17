using LibGit2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using WingetRepoBrowserCore;

namespace WingetRepoBrowserCoreTests;


[TestClass]
public class RepoTests
{
	[TestMethod]
	public void TestGetChangedYamlDirectories()
	{
		DateTime since = DateTime.UtcNow.AddDays(-12);
		string repoRoot = @"V:\projects_os_git\winget-pkgs"; // V:\projects_os_git\winget-pkgs\manifests
		var dirs = GitHelpers.GetChangedYamlDirectories(repoRoot, since).ToArray();

	}

	[TestMethod]
	public void TestFindRepoRoot()
	{
		string repoSubPath = @"V:\projects_os_git\winget-pkgs\manifests";
		string? repoRoot = GitHelpers.FindRepoRoot(repoSubPath);
	}

	[TestMethod]
	public void TestGitLogAlternative()
	{
		string repoPath = @"V:\projects_os_git\winget-pkgs";

		using (var repo = new Repository(repoPath))
		{
			DateTime sinceDate = new DateTime(2025, 12, 15, 17, 9, 0);

			var filter = new CommitFilter { SortBy = CommitSortStrategies.Time };

			var filteredCommits = repo.Commits.QueryBy(filter).TakeWhile(commit => commit.Committer.When >= sinceDate).ToList();
			Commit oldestCommit = filteredCommits.Last();
			Commit newestCommit = filteredCommits.First();

			Debug.WriteLine($"#oldestCommit timestamp: {oldestCommit.Committer.When.ToLocalTime()}");
			Debug.WriteLine($"#newestCommit timestamp: {newestCommit.Committer.When.ToLocalTime()}");

			TreeChanges changes = repo.Diff.Compare<TreeChanges>(oldestCommit!.Tree, newestCommit!.Tree);
			foreach (var change in changes)
			{
				Debug.WriteLine(change.Path);
			}
		}
	}


	[TestMethod]
	public void TestGitLog()
	{
		string repoPath = @"V:\projects_os_git\winget-pkgs";

		using (var repo = new Repository(repoPath))
		{
			// Define the cutoff date
			DateTime sinceDate = new DateTime(2025, 12, 15, 17, 10, 0);

			var filter = new CommitFilter
			{
				SortBy = CommitSortStrategies.Time
			};

			Commit? oldestCommit = null;
			Commit? newestCommit = null;
			foreach (Commit commit in repo.Commits.QueryBy(filter))
			{
				if (commit.Committer.When < sinceDate)
				{
					break;
				}

				Debug.WriteLine($"#commit timestamp: {commit.Committer.When.ToLocalTime()}");

				if (newestCommit == null)
				{
					newestCommit = commit;
				}

				// several AIs suggested to do it this way: create diff between each commit and accumulate the found paths
				// this is extremely slow !!!

				// Show changed files in this commit

				//TreeChanges changes = repo.Diff.Compare<TreeChanges>(commit.Parents.FirstOrDefault()?.Tree, commit.Tree);
				//foreach (var change in changes)
				//{
				//	Debug.WriteLine(change.Path);
				//}

				oldestCommit = commit;
			}

			TreeChanges changes2 = repo.Diff.Compare<TreeChanges>(oldestCommit!.Tree, newestCommit!.Tree);
			foreach (var change in changes2)
			{
				Debug.WriteLine(change.Path);
			}



		}


	}


}
