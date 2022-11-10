using System.Collections.Generic;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using WingetRepoBrowserCore;

using YamlDotNet.RepresentationModel;

namespace WingetRepoBrowserTests
{
	[TestClass]
	public class YamlTest
	{
		[TestMethod]
		//[Ignore][Explicit]
		public void TestLoadMultiFileYaml()
		{
			const string MainYamlFilePath = @"V:\projects_os_git\winget-pkgs\manifests\a\AxisCommunications\AxisCameraStation\5.37.304\AxisCommunications.AxisCameraStation.yaml";
			MultiFileYaml mfy = new YamlFileHelper().LoadMultiFileYaml(MainYamlFilePath);

		}


		[TestMethod]
		//[Ignore][Explicit]
		public void TestDeserializeYaml()
		{
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\7\7zip\7zip\21.07\7zip.7zip.yaml";
			ManifestPackage_1_0_0 package = new YamlFileHelper().ReadYamlFile(yamlFile).Manifest;
			string locale = package.PackageLocale;
		}


		[TestMethod]
		//[Ignore][Explicit]
		public void TestModifyYaml()
		{
			//string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\7Zip\7Zip\19.0.0.yaml";
			//string yamlFileTarget = @"e:\7Zip_19.0.0.yaml";
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\a\AcroSoftware\CutePDFWriter\4.0\AcroSoftware.CutePDFWriter.yaml";
			string yamlFileTarget = @"e:\cutepdf4.yaml";
			YamlFileHelper yamlFileHelper = new YamlFileHelper();
			ManifestPackage_1_0_0 package = yamlFileHelper.ReadYamlFile(yamlFile).Manifest;
			package.Installers[0].InstallerUrl = "cutepdf.exe";
			yamlFileHelper.WriteYamlFile(yamlFileTarget, package);
		}

		[TestMethod]
		//[Ignore][Explicit]
		public void TestReadManifestVersion()
		{
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\a\AcroSoftware\CutePDFWriter\4.0\AcroSoftware.CutePDFWriter.yaml";
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
