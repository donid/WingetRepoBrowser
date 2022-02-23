using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
	public class ManifestPackageVM
	{

		ManifestInstallerVM[] _installerVMs;

		MultiFileYaml _multiFileYaml;
		internal MultiFileYaml MultiFileYaml { get { return _multiFileYaml; } }

		ParsedPackageVersion _parsedPackageVersion;
		public ParsedPackageVersion ParsedPackageVersion { get { return _parsedPackageVersion; } }

		public ManifestPackageVM(MultiFileYaml multiFileYaml)
		{
			_multiFileYaml = multiFileYaml;
			_installerVMs = multiFileYaml.Installers.Select(item => new ManifestInstallerVM(item)).ToArray();
			_parsedPackageVersion = new ParsedPackageVersion(_multiFileYaml.MainPackage.PackageVersion);
		}	

		IEnumerable<ManifestInstaller_1_0_0> GetInstallers()
		{
			return _multiFileYaml.Installers;
		}

		public string FilePath { get { return _multiFileYaml.MainYamlFilePath; } }


		public string Id { get { return _multiFileYaml.MainPackage.PackageIdentifier; } }

		public string Name { get { return _multiFileYaml.DefaultLocalePackage.PackageName; } }

		public string Version { get { return _multiFileYaml.MainPackage.PackageVersion; } }

        public DateTime? ReleaseDate
        {
            get
            {
                DateTime? releaseDate = _multiFileYaml.InstallerPackage?.ReleaseDate;
                if (releaseDate!=null)
                {
                    return releaseDate;
                }
                return GetInstallers().Max(item => item.ReleaseDate);
            }
        }

        public string Publisher { get { return _multiFileYaml.DefaultLocalePackage.Publisher; } }

		public string Moniker { get { return _multiFileYaml.DefaultLocalePackage.Moniker; } }

		public string Author { get { return _multiFileYaml.DefaultLocalePackage.Author; } }

		public string License { get { return _multiFileYaml.DefaultLocalePackage.License; } }

		public string LicenseUrl { get { return _multiFileYaml.DefaultLocalePackage.LicenseUrl; } }
		public string PrivacyUrl { get { return _multiFileYaml.DefaultLocalePackage.PrivacyUrl; } }
		public string PublisherUrl { get { return _multiFileYaml.DefaultLocalePackage.PublisherUrl; } }

		public string MinOSVersion { get { return _multiFileYaml.InstallerPackage?.MinimumOSVersion; } }

		public string PackageUrl { get { return _multiFileYaml.DefaultLocalePackage.PackageUrl; } }

		public string ShortDescription { get { return _multiFileYaml.DefaultLocalePackage.ShortDescription; } }
		public string Description { get { return _multiFileYaml.DefaultLocalePackage.Description; } }

		public string Tags { get { return SafeJoin("|", _multiFileYaml.DefaultLocalePackage.Tags); } }

		static string SafeJoin(string separator, IEnumerable<string> arr)
		{
			if (arr == null)
			{
				return null;
			}
			return string.Join(separator, arr);
		}

		public string InstallerType { get { return _multiFileYaml.InstallerPackage?.InstallerType; } }

		public ManifestInstallerVM[] Installers { get { return _installerVMs; } }
		public int InstallersCount { get { return _installerVMs == null ? 0 : _installerVMs.Length; } }


		public string FileExtensions { get { return SafeJoin("|", _multiFileYaml.InstallerPackage?.FileExtensions); } } // InstallerPackage will be missing, when reading it threw an exception

		public string Protocols { get { return SafeJoin("|", _multiFileYaml.InstallerPackage?.Protocols); } }

		public string Commands { get { return SafeJoin("|", _multiFileYaml.InstallerPackage?.Commands); } }

		public string InstallersArch { get { return SafeJoin("|", GetInstallers().Select(item => item.Architecture)); } }
		public string InstallersLocale { get { return SafeJoin("|", GetInstallers().Select(item => item.InstallerLocale)); } }
		public string InstallersInstallerType { get { return SafeJoin("|", GetInstallers().Select(item => item.InstallerType)); } }

		public string ManifestSwitchInteractive { get { return _multiFileYaml.InstallerPackage?.InstallerSwitches?.Interactive; } }
		public string ManifestSwitchSilent { get { return _multiFileYaml.InstallerPackage?.InstallerSwitches?.Silent; } }
		public string ManifestSwitchSilentWithProgress { get { return _multiFileYaml.InstallerPackage?.InstallerSwitches?.SilentWithProgress; } }


		public string ManifestType { get { return _multiFileYaml.MainPackage.ManifestType; } }

		public string PackageLocale { get { return string.Join("|", _multiFileYaml.LocalePackages.Select(p=>p.PackageLocale)); } }

		public string DefaultLocale { get { return _multiFileYaml.MainPackage.DefaultLocale; } }

		private string GetDebuggerDisplay()
		{
			return Id;
		}

	
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
