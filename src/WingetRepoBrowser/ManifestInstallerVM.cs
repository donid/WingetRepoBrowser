using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	public class ManifestInstallerVM
	{
		ManifestInstaller _installers;

		public ManifestInstallerVM(ManifestInstaller installers)
		{
			_installers = installers;
		}


		public string Arch { get { return _installers.Arch; } }

		public string Url { get { return _installers.Url; } }

		public string Sha256 { get { return _installers.Sha256; } }

		public string SignatureSha256 { get { return _installers.SignatureSha256; } }

		public string InstallerType { get { return _installers.InstallerType; } }

		public string Language { get { return _installers.Language; } }

		public string Scope { get { return _installers.Scope; } }


		public string SystemAppId { get { return _installers.SystemAppId; } }

		//public ManifestSwitches Switches { get { return _installers.Switches; } }


		public string SwitchesSilent { get { return _installers.Switches?.Silent; } }

		public string SwitchesSilentWithProgress { get { return _installers.Switches?.SilentWithProgress; } }

		public string SwitchesCustom { get { return _installers.Switches?.Custom; } }

		public string SwitchesInstallLocation { get { return _installers.Switches?.InstallLocation; } }

		public string SwitchesLanguage { get { return _installers.Switches?.Language; } }

		public string SwitchesLog { get { return _installers.Switches?.Log; } }
	}
}
