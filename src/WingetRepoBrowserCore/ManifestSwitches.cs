using System;
using System.Linq;

namespace WingetRepoBrowserCore
{
	/// <summary>
	/// winget by default specifies silent or quiet mode to the installers.  The following additional
	/// switches can be used to change the install behavior if supported by the InstallerType.
	/// When scripting, custom switches may also be passed on the command line to winget.
	/// The following switches are supported: Custom, Silent, SilentWithProgress, Interactive, Language, Log and InstallLocation.
	/// </summary>
	public class ManifestSwitches
	{
		// During any installation, only one of the next three switches [Silent, SilentWithProgress, Interactive] will be passed to the
		// installer when provided by the user.

		/// <summary>
		/// switches passed to the installer for silent installation
		///  Silent represents the value that should be passed to the installer when the user chooses a silent or quiet install.
		/// For example, some installers support "/s".
		/// Restrictions: [min: 1, max:40] 
		/// </summary>
		public string Silent { get; set; }

		/// <summary>
		/// switches passed to the installer for non-interactive install
		///  SilentWithProgress represents the value that should be passed to the installer when the user chooses to install a non-interactive install.
		/// For example, some installers support "passive".
		/// </summary>
		public string SilentWithProgress { get; set; }

		/// <summary>
		/// custom switches passed to the installer
		/// Custom switches will be passed directly to the installer by winget.
		/// Restrictions: [min: 1, max:128]
		/// </summary>
		public string Custom { get; set; }

		/// <summary>
		/// specifies alternate location to install package
		/// Some installers allow for installing to an alternate location.   A user may want to redirect the default install to a different location.  
		/// In order to redirect the install location, the user will pass in a installation path to the installer.  For example: --installlocation "c:\mytool". 
		/// The folder path will be saved as a token in the client: <INSTALLPATH>.  Therefore, if the installer supports install location redirection, 
		/// then the InstallLocation switch must be the flag that the installer expects to redirect the installation path.  
		/// For example:  /InstallLocation=<INSTALLPATH>.
		/// InstallLocation must include the <INSTALLPATH> token.
		/// example: /DIR=<INSTALLPATH>
		/// </summary>
		public string InstallLocation { get; set; }

		/// <summary>
		/// experimental
		/// Some installers include all localized resources.  By specifying a Language switch, winget will pass the value of language to the installer,
		/// when the installer is called.
		/// Language is not supported in this preview (5/24/2020)
		/// example: en-US
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// specifies log redirection switches and path
		/// Installers often write logging files.  A user may want to redirect the log to a different location.  In order to redirect the log file, the user will 
		/// pass in a log file path to the installer.  For example: --log "%temp%\mylog.txt".  The file will be saved as a token in the client: <LOGPATH>.  Therefore, 
		/// if the installer supports log redirection, then the Log switch should be the flag that the installer expects to provide the path to the log 
		/// file.  For example:  /LOG=<LOGPATH>.
		/// Log must include the <LOGPATH> token.
		/// example: /LOG=<LOGPATH>
		/// </summary>
		public string Log { get; set; }
	}
}
