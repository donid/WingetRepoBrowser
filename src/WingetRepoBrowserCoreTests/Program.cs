using System.Collections.Generic;
using System.IO;

using WingetRepoBrowserCore;

using WingetRepoBrowserTests;

namespace WingetRepoBrowserCoreTests
{
	class Program
	{
		static void Main(string[] args)
		{

			new YamlTest().TestDeserializeYaml();
			//new YamlTest().TestModifyYaml();
			return;

			string yamlFileTarget = @"e:\7Zip_19.0.0.yaml";
			ManifestPackage_1_0_0 package = new YamlFileHelper().ReadYamlFile(yamlFileTarget).Manifest;


		}
	}
}
