using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
	public class ManifestPackageVM
	{

		ManifestPackage_1_0_0 _package;
		internal ManifestPackage_1_0_0 Package { get { return _package; } }

		string _filePath;
		ManifestInstallerVM[] _installerVMs;

		MultiFileYaml _multiFileYaml;
		ManifestPackage_1_0_0 _defaultLocalePackage;

		ManifestPackage_1_0_0 _installerPackage;
		internal ManifestPackage_1_0_0 InstallerPackage { get { return _installerPackage; } }

		ParsedPackageVersion _parsedPackageVersion;
		public ParsedPackageVersion ParsedPackageVersion { get { return _parsedPackageVersion; } }

		public ManifestPackageVM(ManifestPackage_1_0_0 package, string filePath, MultiFileYaml multiFileYaml)
		{
			_package = package;
			_filePath = filePath;
			_multiFileYaml = multiFileYaml;
			_defaultLocalePackage = _multiFileYaml.Packages.FirstOrDefault(p => p.PackageLocale == package.DefaultLocale);
			_installerPackage = _multiFileYaml.Packages.FirstOrDefault(p => p.ManifestType == "installer");
			_installerVMs = _installerPackage?.Installers.Select(item => new ManifestInstallerVM(item)).ToArray();
			_parsedPackageVersion = new ParsedPackageVersion(package.PackageVersion);
		}

		public ManifestPackageVM(ManifestPackage_1_0_0 package, string filePath)
		{
			_package = package;
			_filePath = filePath;
			_installerVMs = _package.Installers.Select(item => new ManifestInstallerVM(item)).ToArray();
			_parsedPackageVersion = new ParsedPackageVersion(package.PackageVersion);
		}

		ManifestPackage_1_0_0 GetDefaultPackage()
		{
			return _defaultLocalePackage ?? _package;
		}
		ManifestPackage_1_0_0 GetInstallerPackage()
		{
			return _installerPackage ?? _package;
		}

		public string FilePath { get { return _filePath; } }


		public string Id { get { return _package.PackageIdentifier; } }

		public string Name { get { return GetDefaultPackage().PackageName; } }

		public string Version { get { return _package.PackageVersion; } }

		public string Publisher { get { return GetDefaultPackage().Publisher; } }

		public string Moniker { get { return GetDefaultPackage().Moniker; } }

		public string Author { get { return GetDefaultPackage().Author; } }

		public string License { get { return GetDefaultPackage().License; } }

		public string LicenseUrl { get { return GetDefaultPackage().LicenseUrl; } }
		public string PrivacyUrl { get { return GetDefaultPackage().PrivacyUrl; } }
		public string PublisherUrl { get { return GetDefaultPackage().PublisherUrl; } }

		public string MinOSVersion { get { return GetInstallerPackage().MinimumOSVersion; } }

		public string PackageUrl { get { return GetDefaultPackage().PackageUrl; } }

		public string ShortDescription { get { return GetDefaultPackage().ShortDescription; } }
		public string Description { get { return GetDefaultPackage().Description; } }

		public string Tags { get { return SafeJoin("|", GetDefaultPackage().Tags); } }

		static string SafeJoin(string separator, IEnumerable<string> arr)
		{
			if (arr == null)
			{
				return null;
			}
			return string.Join(separator, arr);
		}

		public string InstallerType { get { return GetInstallerPackage().InstallerType; } }

		public ManifestInstallerVM[] Installers { get { return _installerVMs; } }
		public int InstallersCount { get { return _installerVMs == null ? 0 : _installerVMs.Length; } }


		public string FileExtensions { get { return SafeJoin("|", _package.FileExtensions); } }

		public string Protocols { get { return SafeJoin("|", _package.Protocols); } }

		public string Commands { get { return SafeJoin("|", _package.Commands); } }

		public string InstallersArch { get { return SafeJoin("|", GetInstallerPackage().Installers?.Select(item => item.Architecture)); } }
		public string InstallersLocale { get { return SafeJoin("|", GetInstallerPackage().Installers?.Select(item => item.InstallerLocale)); } }
		public string InstallersInstallerType { get { return SafeJoin("|", GetInstallerPackage().Installers?.Select(item => item.InstallerType)); } }

		public string ManifestSwitchInteractive { get { return GetInstallerPackage().InstallerSwitches?.Interactive; } }
		public string ManifestSwitchSilent { get { return GetInstallerPackage().InstallerSwitches?.Silent; } }
		public string ManifestSwitchSilentWithProgress { get { return GetInstallerPackage().InstallerSwitches?.SilentWithProgress; } }


		public string ManifestType { get { return _package.ManifestType; } }
		public string PackageLocale { get { return _package.PackageLocale; } }
		public string DefaultLocale { get { return _package.DefaultLocale; } }

		private string GetDebuggerDisplay()
		{
			return ToString();
		}

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

	public class MultiFileYaml
	{
		public List<ManifestPackage_1_0_0> Packages { get; } = new List<ManifestPackage_1_0_0>();
	}

	public class ParsedPackageVersion
	{
		private string[] _parts;
		private int?[] _intParts;

		public ParsedPackageVersion(string version)
		{
			_parts = version.Split('.');
			_intParts = _parts.Select(p => ParseInt(p)).ToArray();
		}

		private static int? ParseInt(string text)
		{
			if (!int.TryParse(text, out int result))
			{
				return null;
			}
			return result;
		}

		public override string ToString()
		{
			List<string> resultParts = new List<string>();
			for (int index = 0; index < _intParts.Length; index++)
			{
				string part;
				if (_intParts[index].HasValue)
				{
					part = _intParts[index].Value.ToString("0000000000");
				}
				else
				{
					part = _parts[index];
				}
				resultParts.Add(part);
			}
			return string.Join(".", resultParts);
		}
	}

}
