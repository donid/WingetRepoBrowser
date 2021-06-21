# WingetRepoBrowser
A graphical (GUI) browser for the winget package repository

Microsoft is creating a new Windows Package Manager CLI (aka winget) which is based on a [Git repository](https://github.com/microsoft/winget-pkgs) that contains yaml-based package descriptions. They have stated that there will be no 'gallery' to browse through the available packages, so I have created a little WinForms Application to fill this gap. It uses a DevExpress GridControl, which provides powerful [search, sort and filtering features.](https://docs.devexpress.com/WindowsForms/833/controls-and-libraries/data-grid/end-user-capabilities)

![ApplicationScreenshot](/screenshot.png)

**Usage:**

Clone the winget-pkgs repository to a local folder and specify that folder in WingetRepoBrowser and click on 'Search'.

**Features**

- WingetRepoBrowser can create a local installers cache by downloading (with SHA-hash check) selected packages and storing them in a local folder hierarchy. The easiest way to get started is to fill 'Installers-Folder' and select multiple packages (with Shift- and or Control-key) and then click 'CreateSubFolders For Selected'. This step has to be done only once, except you want to add new packages (not versions) to your cache. Now use 'Check For New Downloads' to see the available downloads.
- versions-count when grouping and group-count (number of unique packages)
- Downloading is currently not supported for manifests that have the PackageVersion 'latest'.

**New Features in v0.2.0**
- added context menu "OpenGitRepo"
- searching for yaml files doesn't block UI anymore
- fixed "Ignore selected version(s)"

**New Features in v0.1.2**

- moved from command-line switches to AppSettings.json (that allows to configure which locales should be downloaded)
- context menu in 'New Downloads'-window allows to ignore a ParsedVersion for download (VersionsToIgnoreDownload stored .wingetid-files)
- ParsedVersion-column allows to sort by PackageVersion (using a separate column makes it easier to find problems with the sorting-implementation)


If you don't like the fact that the subfolders are named by the package-id, you can change the names manually - the folders are identified by the *.wingetid files.

**Changes in v0.1.0**

*Initial support for manifest schema v1.0.0*

If you have downloaded installers to a folder with WingetRepoBrowser, you should delete all .yaml-files in that folder or rename them with PowerShell e.g.:

>Get-ChildItem -Filter *.yaml -Recurse -Path W:\installers | Rename-Item -NewName {$_.name -replace '.yaml','.yaml.old' }
