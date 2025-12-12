using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace WingetRepoBrowser
{
    public static class GitHelpers
    {
        private static string? FindRepoRoot(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;
            string? discovered = Repository.Discover(path);
            if (string.IsNullOrEmpty(discovered)) return null;
            return Path.GetFullPath(Path.Combine(discovered, ".."));
        }

        public static Task<RepoCommitInfo?> GetRepoCommitInfoAsync(string repoPath)
        {
            return Task.Run(() =>
            {
                try
                {
                    var root = FindRepoRoot(repoPath);
                    if (root == null || !Repository.IsValid(root))
                        return (RepoCommitInfo?)null;

                    using var repo = new Repository(root);

                    var localCommit = repo.Head?.Tip ?? repo.Commits.FirstOrDefault();
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
                    var remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == "origin") ?? repo.Network.Remotes.FirstOrDefault();
                    if (remote != null)
                    {
                        try
                        {
                            var refSpecs = remote.FetchRefSpecs.Select(r => r.Specification);
                            Commands.Fetch(repo, remote.Name, refSpecs, new FetchOptions(), null);
                        }
                        catch
                        {
                            // ignore fetch failures
                        }

                        var remoteBranch = repo.Branches.FirstOrDefault(b => b.IsRemote && (b.FriendlyName.EndsWith("/main") || b.FriendlyName.EndsWith("/master")));
                        if (remoteBranch == null && repo.Head != null)
                        {
                            var tracked = repo.Head.TrackedBranch;
                            if (tracked != null && tracked.IsRemote)
                                remoteBranch = tracked;
                        }

                        if (remoteBranch?.Tip != null)
                        {
                            var tip = remoteBranch.Tip;
                            remoteInfo = new CommitInfo
                            {
                                Sha = tip.Sha,
                                Date = tip.Author.When,
                                Message = tip.MessageShort ?? ""
                            };
                        }
                    }

                    return new RepoCommitInfo { Local = localInfo, Remote = remoteInfo };
                }
                catch
                {
                    return (RepoCommitInfo?)null;
                }
            });
        }
    }
}
