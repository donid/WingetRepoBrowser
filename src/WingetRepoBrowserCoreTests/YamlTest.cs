using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WingetRepoBrowserCore;
using YamlDotNet.Serialization;

namespace WingetRepoBrowserTests
{
	[TestClass]
	public class YamlTest
	{
		[TestMethod]
		//[Ignore][Explicit]
		public void TestModifyYaml()
		{
			//string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\7Zip\7Zip\19.0.0.yaml";
			//string yamlFileTarget = @"e:\7Zip_19.0.0.yaml";
			string yamlFile = @"V:\projects_os_git\winget-pkgs\manifests\AcroSoftware\CutePDFWriter\4.0.0.2.yaml";
			string yamlFileTarget = @"e:\cutepdf4.yaml";
			ManifestPackage package = Helpers.ReadYamlFile(yamlFile);
			package.Installers[0].Url = "cutepdf.exe";
			Helpers.WriteYamlFile(yamlFileTarget, package);

		}

	}
}
