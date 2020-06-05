using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingetRepoBrowserCore;
using WingetRepoBrowserTests;

namespace WingetRepoBrowserCoreTests
{
	class Program
	{
		static void Main(string[] args)
		{

			new YamlTest().TestModifyYaml();
			return;

			string yamlFileTarget = @"e:\7Zip_19.0.0.yaml";
			ManifestPackage package = Helpers.ReadYamlFile(yamlFileTarget);


		}
	}
}
