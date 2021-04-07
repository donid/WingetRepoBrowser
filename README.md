# WingetRepoBrowser
A graphical (GUI) browser for the winget package repository

Microsoft is creating a new Windows Package Manager CLI (aka winget) which is based on a [Git repository](https://github.com/microsoft/winget-pkgs) that contains yaml-based package descriptions. They have stated that there will be no 'gallery' to browse through the available packages, so I have created a little WinForms Application to fill this gap. It uses a DevExpress GridControl, which provides powerful [search, sort and filtering features.](https://docs.devexpress.com/WindowsForms/833/controls-and-libraries/data-grid/end-user-capabilities)

:warning: Winget changed its manifest schema to v1.0.0 - you need to use WingetRepoBrowser version 0.1.0 or higher.


![ApplicationScreenshot](/screenshot.png)

**Usage:**

Clone the winget-pkgs repository to a local folder and specify that folder in WingetRepoBrowser and click on 'Search'.

**Commandline Arguments:**

- First Arg will be used to fill 'Repo-Folder' edit
- Second Arg will be used to fill 'Installers-Folder' edit

**New Feature in v0.0.2**

WingetRepoBrowser can create a local installers cache by downloading (with SHA-hash check) selected packages and storing them in a local folder hierarchy. The easiest way to get started is to fill 'Installers-Folder' and select multiple packages (with Shift- and or Control-key) and then click 'CreateSubFolders For Selected'. This step has to be done only once, except you want to add new packages (not versions) to your cache. Now use 'Check For New Downloads' to see the available downloads.

If you don't like the fact that the subfolders are named by the package-id, you can change the names manually - the folders are identified by the *.wingetid files.

**Changes in v0.0.3**

- fixed crash when the yaml-file contained a property that was missing in the datamodel
- improved installer-cache downloads (exception handling, file naming)
- added versions-count when grouping and group-count (number of unique packages)


**Changes in v0.1.0**

*Initial support for manifest schema v1.0.0*

If you have downloaded installers to a folder with WingetRepoBrowser, you should delete all .yaml-files in that folder or rename them with PowerShell e.g.:

>Get-ChildItem -Filter *.yaml -Recurse -Path W:\installers | Rename-Item -NewName {$_.name -replace '.yaml','.yaml.old' }


Downloading is currently only supported for 'singleton' manifests that don't have the PackageVersion 'latest'.