using System;
using System.Diagnostics;

namespace WingetRepoBrowserCore
{
	// Manifest Specification:
	// https://github.com/microsoft/winget-cli/blob/master/doc/ManifestSpecv1.0.md
	// https://docs.microsoft.com/en-us/windows/package-manager/package/manifest?tabs=minschema%2Ccompschema


	/*
	 # Switches in installers can override the root specified switches. See definition earlier in this document.
    Switches:
      Language: /en-US
      Custom: /s

    # This is an example of an additional installer.
    # See further restrictions earlier in this document.
    # Support for multiple installers are not supported in this preview (5/24/2020)
  - Arch: x64
    Url: https://contosa.net/publiccontainer/contosainstaller64.exe
    Sha256: 69D84CA8899800A5575CE31798293CD4FEBAB1D734A07C2E51E56A28E0DF8C83
    Language: en-US
    Scope: user

    # Localized values will provide links and text to match the users settings.  For example the following links and text will be displayed instead.
Localization:
  - Language: es-MX
    Description: Text to display for es-MX
    Homepage: https://github.com/microsoft/msix-packaging/es-MX
    LicenseUrl: https://github.com/microsoft/msix-packaging/blob/master/LICENSE-es-MX
	*/

	[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
	public class ManifestPackage_1_0_0
	{
		/// <summary>
		/// Mandatory!
		/// publisher.package format
		/// example: microsoft.teams
		/// /// Id is a required field.  It MUST include the publisher name and application name separated by a period.
		/// The Id convention and folder convention MUST match.  Therefore all entries MUST look like this:
		/// ID: PublisherName.ApplicationName
		/// and the folder structure PublisherName\ApplicationName\ApplicationName-Version.YAML
		/// Restrictions: No white spaces allowed. [min: 4, max:255]
		/// </summary>
		public string PackageIdentifier { get; set; }

		/// <summary>
		/// Mandatory!
		/// the name of the application
		/// example: Microsoft Teams
		/// Name is a required field.  It should be the friendly name of the application.
		/// Restrictions: [min: 1, max:128]
		/// </summary>
		public string PackageName { get; set; }

		/// <summary>
		/// the common name someone may use to search for the package
		/// example: teams
		/// AppMoniker is the common name someone may use to search for the application.
		/// Restrictions:  No white spaces allowed. [min: 1, max:40]
		/// </summary>
		public string Moniker { get; set; }

		/// <summary>
		/// Mandatory!
		/// version numbering format for package version
		/// example: 2.38a
		/// /// Version is a required field.  It is the specific version of this copy of the application.
		/// Versions should be separated by a period, but we will support other deliminators.
		/// Versions should be limited to four fields: Major.Minor.Build.Update.
		/// Versions will be sorted as integers following the following pattern: Major.Minor.Build.Patch.
		/// Restrictions: 4 sections with max value of 65535.  For example:65535.65535.65535.65535
		/// </summary>
		public string PackageVersion { get; set; }

		/// <summary>
		/// DateOnly exists only in .Net 6 not in netstandard 2
		/// </summary>
		public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Mandatory!
		/// the name of the publisher
		/// example: Microsoft Corporation
		/// Publisher is a required field.  It should be the legal company name.
		/// Restrictions: [min: 1, max:128]
		/// </summary>
		public string? Publisher { get; set; }



		public string? Author { get; set; }

		/// <summary>
		/// Mandatory!
		/// the open source license or copyright
		/// example: Copyright (c) Microsoft Corporation. All rights reserved.
		/// License is a required field.  License provides the type of license the application is provided under.  
		/// For example: BSD, MIT, Apache, Microsoft Public License, commercial
		/// Restrictions: [min: 1, max:40]
		/// </summary>
		public string? License { get; set; }


		/// <summary>
		/// valid secure URL to license
		/// example: https://docs.microsoft.com/en-us/MicrosoftTeams/assign-teams-licenses
		/// LicenseURL provides a link to the license for the user to read.  
		/// Restrictions: The LicenseUrl must be a valid secure URL, for example beginning with https and 
		/// followed by a hostname.  [min: 10, max:2000]
		/// </summary>
		public string? LicenseUrl { get; set; }

		/// <summary>
		/// The publisher privacy page or the package privacy page
		/// </summary>
		public string? PrivacyUrl { get; set; }
		/// <summary>
		/// The publisher home page
		/// </summary>
		public string? PublisherUrl { get; set; }
		/// <summary>
		/// The publisher support page
		/// </summary>
		public string? PublisherSupportUrl { get; set; }

		public string[] Platform { get; set; }

		/// <summary>
		/// version numbering format for minimum version of Windows supported
		/// example: 10.0.0.0
		/// MinOSVersion uses the Windows version to limit installations on unsupported platforms.  
		/// For example specifying 10.0.18362.0 will only allows this tool to be installed on Windows build 1903 or greater.
		/// Restrictions: must follow Windows versioning model. 4 sections with max value of 65535.  For example:65535.65535.65535.65535
		/// </summary>
		public string? MinimumOSVersion { get; set; }

		/// <summary>
		/// valid secure URL for the package
		/// example: https://www.microsoft.com/microsoft/teams
		/// Homepage is a URL where the user can find more information on the tool.
		/// Restrictions: The Homepage must be a valid secure URL, for example beginning with https and 
		/// followed by a hostname.  [min: 10, max:2000]
		/// </summary>
		public string? PackageUrl { get; set; }

		/// <summary>
		/// The short description of the package
		/// example: The hub for teamwork in Microsoft 365
		/// Description should be friendly providing insights into the value of the tool.
		/// Restrictions: [min: 3, max:256]
		/// </summary>
		public string? ShortDescription { get; set; }

		/// <summary>
		/// The full description of the package
		/// Restrictions: [min: 3, max:10000]
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// datatype: 'list' !?!?
		/// additional strings a user would use to search for the package
		/// Tags are comma separated list.  They represent strings that the user may use to search for a given tool.
		/// Restrictions: [min: 1, max:40] 
		/// </summary>
		public string[] Tags { get; set; }

		/// <summary>
		/// Mandatory!
		/// enumeration of supported installer types (exe, msi, msix)
		/// InstallerType is a required field.  Supported types are inno, wix, msi, nullsoft, zip, appx, msix and exe.
		/// The winget command tool uses this value to assist in installing this application.
		/// If the value is an exe, you will need to provide the quiet switches.
		/// zip is not supported in this preview (5/24/2020)  
		/// Restrictions: [min: 1, max:40] 
		/// </summary>
		public string? InstallerType { get; set; }

		public string[] InstallModes { get; set; }


		/// <summary>
		/// Mandatory!
		/// nested map of keys for specific installer
		/// When more than one installer type exists for the specified version of the package, an instance of InstallerType can be placed under each of the Installers
		/// </summary>
		public ManifestInstaller_1_0_0[] Installers { get; set; }

		/// <summary>
		///  datatype: 'list' !?!?
		///  list of file extensions the package could support
		///  FileExtensions is a comma separated list.  FileExtensions provides the list of extensions the application could support.
		/// FileExtensions are not supported in this preview (5/24/2020)
		/// Restrictions: [min: 1, max:40] 
		/// </summary>
		public string[] FileExtensions { get; set; }

		/// <summary>
		///  datatype: 'list' !?!?
		///  not yet used in the wild!
		///  list of protocols the package provides a handler for
		///  Protocols is a comma separated list.  Protocols provides the list of protocols the application provides a handler for.
		/// Protocols are not supported in this preview (5/24/2020)
		/// Restrictions: [min: 1, max:40] 
		/// example: ms-winget
		/// </summary>
		public string[] Protocols { get; set; }

		/// <summary>
		///  datatype: 'list' !?!?
		/// list of commands or aliases the user would use to run the package
		/// Commands are the common executable or alias that the user might type trying to run the application.
		/// For example "code" for VSCode.  If multiple commands are supported, the commands must be separated by a comma.
		/// Restrictions: [min: 1, max:40] 
		/// </summary>
		public string[] Commands { get; set; }

		public ManifestSwitches InstallerSwitches { get; set; }


		/// <summary>
		///  not yet used in the wild!
		/// experimental
		/// Interactive represents the value that should be passed to the installer when the tool requires user interaction.  If the installer has a flag
		/// that when passed to the installer, causes it to require user input, it should be provided here.  This flag will be used when the user passes the
		/// --interactive switch to the installer.  
		/// Interactive is not supported in this preview (5/24/2020)
		/// example: /ShowEula
		/// </summary>
		public string? Interactive { get; set; }


		/// <summary>
		/// not yet used in the wild! 4/2021
		/// The distribution channel
		/// Restrictions: [min: 1, max:16]
		/// </summary>
		public string? Channel { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// custom switches passed to the installer
		/// </summary>
		public string? Custom { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// switches passed to the installer for silent installation
		/// </summary>
		public string? Silent { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// switches passed to the installer for non-interactive install
		/// </summary>
		public string? SilentWithProgress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string? DefaultLocale { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string? PackageLocale { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string? InstallerLocale { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// specifies log redirection switches and path
		/// </summary>
		public string? Log { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// specifies alternate location to install package
		/// </summary>
		public string? InstallLocation { get; set; }


		public ExpectedReturnCode[] ExpectedReturnCodes { get; set; }

		/// <summary>
		/// Mandatory!
		/// The 'singleton' format is only valid for packages containing a single installer and a single locale.
		/// If more than one installer or locale is provided, the multiple YAML file format and schema must be used.
		/// </summary>
		public string? ManifestType { get; set; }

		public string? ManifestVersion { get; set; }


		private string GetDebuggerDisplay()
		{
			return $"{PackageIdentifier} {PackageVersion} {ManifestType}";
		}
	}
}
