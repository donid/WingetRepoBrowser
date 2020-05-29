using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	public class ManifestPackageVM
	{

		ManifestPackage _package;
		internal ManifestPackage Package { get { return _package; } }

		string _filePath;
		ManifestInstallerVM[] _installerVMs;

		public ManifestPackageVM(ManifestPackage package, string filePath)
		{
			_package = package;
			_filePath = filePath;
			_installerVMs = _package.Installers.Select(item => new ManifestInstallerVM(item)).ToArray();
		}

		public string FilePath { get { return _filePath; } }
		public int InstallersCount { get { return _installerVMs.Length; } }


		public string Id { get { return _package.Id; } }

		public string Name { get { return _package.Name; } }

		public string Version { get { return _package.Version; } }

		public string Publisher { get { return _package.Publisher; } }

		public string AppMoniker { get { return _package.AppMoniker; } }

		public string Author { get { return _package.Author; } }
	
		public string License { get { return _package.License; } }

		public string LicenseUrl { get { return _package.LicenseUrl; } }

		public string MinOSVersion { get { return _package.MinOSVersion; } }

		public string Homepage { get { return _package.Homepage; } }

		public string Description { get { return _package.Description; } }
	
		public string Tags { get { return _package.Tags; } }

		public string InstallerType { get { return _package.InstallerType; } }

		public ManifestInstallerVM[] Installers { get { return _installerVMs; } }

		public string FileExtensions { get { return _package.FileExtensions; } }

		public string Protocols { get { return _package.Protocols; } }

		public string Commands { get { return _package.Commands; } }

		//TODO
		//public ManifestSwitches Switches { get; set; }

		/*
		/// <summary>
		/// Mandatory!
		/// version number format for manifest version
		/// </summary>
		///  not yet used in the wild!
		/// eigentlich laut doku mandatory: ManifestVersion: 0.1.0
		

		///  not yet used in the wild!
		Localization: # nested map of keys for localization
			- Language: string # locale for display fields and localized URLs
		

		/// <summary>
		///  not yet used in the wild!
		/// experimental
		/// </summary>
		public string Interactive { get; set; }


		/// <summary>
		/// not yet used in the wild!
		/// a string representing the flight ring
		/// </summary>
		public string Channel { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// custom switches passed to the installer
		/// </summary>
		public string Custom { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// switches passed to the installer for silent installation
		/// </summary>
		public string Silent { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// switches passed to the installer for non-interactive install
		/// </summary>
		public string SilentWithProgress { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// experimental
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// specifies log redirection switches and path
		/// </summary>
		public string Log { get; set; }

		/// <summary>
		/// not yet used in the wild! -> used in ManifestSwitches
		/// specifies alternate location to install package
		/// </summary>
		public string InstallLocation { get; set; }

		*/
	}
}
