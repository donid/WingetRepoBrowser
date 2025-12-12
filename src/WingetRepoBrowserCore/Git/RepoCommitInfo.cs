using System;

namespace WingetRepoBrowserCore;


public class CommitInfo
{
	public string Sha { get; set; } = "";
	public DateTimeOffset Date { get; set; }
	public string Message { get; set; } = "";
}

public class RepoCommitInfo
{
	public string ErrorMessage { get; set; } = "";
	public string RepositoryRootPath { get; set; } = "";

	public CommitInfo? Local { get; set; }
	public CommitInfo? Remote { get; set; }
}
