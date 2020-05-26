# WingetRepoBrowser
A graphical (GUI) browser for the winget package repository

Microsoft is creating a new Windows Package Manager CLI (aka winget) which is based on a [Git repository](https://github.com/microsoft/winget-pkgs) that contains yaml-based package descriptions. They have stated that there will be no 'gallery' to browse through the available packages, so I have created a little WinForms Application to fill this gap. It uses a DevExpress GridControl, which provides powerful search, sort and filtering features.

![ApplicationScreenshot](/screenshot.png)

**Usage:**

Clone the winget-pkgs repository to a local folder and specify that folder in WingetRepoBrowser and click on 'Search'.
