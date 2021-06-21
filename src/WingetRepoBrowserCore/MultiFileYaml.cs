using System;
using System.Collections.Generic;

namespace WingetRepoBrowserCore
{
	public class MultiFileYaml
	{
		public List<ManifestPackage_1_0_0> LocalePackages { get; } = new List<ManifestPackage_1_0_0>();
		//private List<string> PackageFilePaths { get; } = new List<string>();


		string _mainYamlFilePath;

		public string MainYamlFilePath
		{
			get { return _mainYamlFilePath; }
		}

		public string InstallerPackageFilePath
		{
			get
			{
				if (InstallerPackage == null)
				{
					return null;
				}
				return YamlFileHelper.GetInstallerPackageFilePath(MainYamlFilePath);
			}
		}


		ManifestPackage_1_0_0 _mainPackage;
		public ManifestPackage_1_0_0 MainPackage
		{
			get { return _mainPackage; }
		}

		ManifestPackage_1_0_0 _installerPackage;
		public ManifestPackage_1_0_0 InstallerPackage
		{
			get { return _installerPackage; }
		}

		ManifestPackage_1_0_0 _defaultLocalePackage;

		public ManifestPackage_1_0_0 DefaultLocalePackage
		{
			get { return _defaultLocalePackage; }
		}

		List<ManifestInstaller_1_0_0> _installers = new List<ManifestInstaller_1_0_0>();
		public List<ManifestInstaller_1_0_0> Installers
		{
			get { return _installers; }
		}


		public void AddPackage(ManifestPackage_1_0_0 package, string yamlFilePath)
		{
			if (package.ManifestType == "singleton") //todo: allow only one - and no 'version'
			{
				_mainYamlFilePath = yamlFilePath;
				_mainPackage = package;
				_defaultLocalePackage = package;
				_installerPackage = package;
				_installers.AddRange(package.Installers);   // todo: should be only one in a singleton?
			}
			else if (package.ManifestType == "version")//todo: allow only one - an no 'singleton'
			{
				_mainYamlFilePath = yamlFilePath;
				_mainPackage = package;
			}
			else if (package.ManifestType == "defaultLocale")
			{
				if (_defaultLocalePackage != null)
				{
					throw new Exception("package is already set!");
				}
				_defaultLocalePackage = package;
			}
			else if (package.ManifestType == "locale")
			{
				LocalePackages.Add(package);
			}
			else if (package.ManifestType == "installer")
			{
				if (_installerPackage != null)
				{
					throw new Exception("package is already set!");
				}
				_installerPackage = package;
				_installers.AddRange(package.Installers);
			}
			else
			{
				throw new Exception();//todo: unexpected type
			}
		}

	}
}
