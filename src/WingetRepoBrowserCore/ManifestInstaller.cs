using System;
using System.Linq;

namespace WingetRepoBrowserCore
{
	/// <summary>
	///  Installers represents the collection of entries that define the actual installer.  The installer provides the architecture, url and hash that 
	/// ensure that the installer has not been tampered with.
	/// </summary>
	public class ManifestInstaller
	{
		/// <summary>
		/// Mandatory!
		/// enumeration of supported architectures
		/// Arch is a required field.  Arch is the architecture of the tool, and is a required field to ensure that the tool will install correctly.
		/// Supported values: arm, arm64, x86, x64 and neutral
		/// example: x64
		/// </summary>
		public string Arch { get; set; }

		/// <summary>
		/// Mandatory!
		/// path to download installation file
		/// Url is a required field.  This provides the path to the installer.
		/// The Url must begin with https:// and followed by a hostname.  
		/// Restrictions: [min: 10, max:2000]
		/// example: https://statics.teams.cdn.office.net/production-windows-x64/1.3.00.4461/Teams_windows_x64.exe
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Mandatory!
		/// SHA256 calculated from installer
		/// Sha256 is a required field. The value is the hash of the installer and used to verify the executable
		/// Restrictions: [valid sha256 hash]
		/// example: 712f139d71e56bfb306e4a7b739b0e1109abb662dfa164192a5cfd6adb24a4e1
		/// </summary>
		public string Sha256 { get; set; }

		/// <summary>
		/// SHA256 calculated from signature file's hash of MSIX file
		/// SignatureSha256 is a recommended field for MSIX files only. The value is the signature file's hash of the MSIX file.  
		/// By providing the SignatureSha256, you can improve the installation performance of the application.
		/// The SignatureSha256 can be found by typing winget create hash -msix <MSIX file>.  For more details see:
		/// https://github.com/microsoft/winget-cli/docs/create.md
		/// Restrictions: [valid sha256 hash]
		/// </summary>
		public string SignatureSha256 { get; set; }

		/// <summary>
		/// InstallerType is a required field if not defined at the root.  Unless specified, the InstallerType will be assumed to be the same InstallerType as the root. 
		/// See further restrictions on InstallerType earlier in this document.
		/// </summary>
		public string InstallerType { get; set; }

		/// <summary>
		/// Language is the specific language of the installer.  If no language is specified, the installer will display for all users.
		/// Language must follow IETF language tag guidelines.
		/// Language is not supported in this preview (5/24/2020)
		/// example: en-us
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// experimental
		/// Scope indicates if the installer is per user or per machine.  
		/// Supported values: user and machine
		/// Unless specified, user is the default.
		/// Scope is not supported in this preview (5/24/2020)
		/// example: user
		/// </summary>
		public string Scope { get; set; }

		/// <summary>
		/// collection of entries to override root keys
		/// </summary>
		public ManifestSwitches Switches { get; set; }

		/// <summary>
		///  not yet used in the wild!
		/// experimental
		/// SystemAppId is a required field.  The value in the field differs depending on the InstallerType.
		/// For MSI it is the product code.  Typically a GUID that is typically found in the uninstall registry location and includes the brackets.
		/// For example:  {5740BD44-B58D-321A-AFC0-6D3D4556DD6C}
		/// [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{3740BD44-B58D-321A-AFC0-6D3D4556DD6C}]
		/// [HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{3740BD44-B58D-321A-AFC0-6D3D4556DD6C}]
		/// The Package Manager will use that value to locate the uninstall string to uninstall the application.
		/// For inno, wix, nullsoft, and exe, the SystemAppId should be a string that is located in either of the Uninstall keys above. 
		/// For MSIX the SystemAppId should be the Package Family Name.  For example: Contoso.Toolbox.Finance_7wekyb3d8bbwe  
		/// Restrictions: [min: 3, max:128] 
		/// example:{3740BD44-B58D-321A-AFC0-6D3D4556DD6C}
		/// </summary>
		public string SystemAppId { get; set; }
	}
}
