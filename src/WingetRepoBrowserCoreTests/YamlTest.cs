﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WingetRepoBrowserCore;
using YamlDotNet.RepresentationModel;

namespace WingetRepoBrowserTests
{
	[TestClass]
	public class YamlTest
	{
		[TestMethod]
		//[Ignore][Explicit]
		public void TestDeserializeYaml()
		{
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\7\7zip\7zip\19.0.0\7zip.7zip.yaml";
			ManifestPackage_1_0_0 package = Helpers.ReadYamlFile(yamlFile);
			string locale = package.PackageLocale;
		}


		[TestMethod]
		//[Ignore][Explicit]
		public void TestModifyYaml()
		{
			//string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\7Zip\7Zip\19.0.0.yaml";
			//string yamlFileTarget = @"e:\7Zip_19.0.0.yaml";
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\a\AcroSoftware\CutePDFWriter\4.0.1.1\AcroSoftware.CutePDFWriter.yaml";
			string yamlFileTarget = @"e:\cutepdf4.yaml";
			ManifestPackage_1_0_0 package = Helpers.ReadYamlFile(yamlFile);
			package.Installers[0].InstallerUrl = "cutepdf.exe";
			Helpers.WriteYamlFile(yamlFileTarget, package);

		}

		[TestMethod]
		//[Ignore][Explicit]
		public void TestReadManifestVersion()
		{
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\a\AcroSoftware\CutePDFWriter\4.0.1.1\AcroSoftware.CutePDFWriter.yaml";
			string version = ReadYamlManifestVersion(yamlFile);
		}

		[TestMethod]
		//[Ignore][Explicit]
		public void TestCheckManifestVersions()
		{
			string yamlFolder = @"V:\projects_os_git\winget-pkgs\manifests\";
			string[] filePaths = Directory.GetFiles(yamlFolder, "*.yaml", SearchOption.AllDirectories);
			foreach (string filePath in filePaths)
			{
				string version = ReadYamlManifestVersion(filePath);
				if (version != "1.0.0")
				{

				}
			}
		}


		private static string ReadYamlManifestVersion(string yamlFile)
		{
			using (StreamReader streamReader = new StreamReader(yamlFile, true))
			{
				YamlStream yaml = new YamlStream();
				yaml.Load(streamReader);
				YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
				YamlScalarNode versionNode = mapping.Children[new YamlScalarNode("ManifestVersion")] as YamlScalarNode;

				return versionNode.Value;
			}
		}
	}
}
