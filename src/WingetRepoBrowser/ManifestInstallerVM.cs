using System;

using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	public class ManifestInstallerVM
	{
		ManifestInstaller_1_0_0 _installers;

		public ManifestInstallerVM(ManifestInstaller_1_0_0 installers)
		{
			_installers = installers;
		}


		public string Arch { get { return _installers.Architecture; } }

		public string Url { get { return _installers.InstallerUrl; } }

		public string Sha256 { get { return _installers.InstallerSha256; } }

		public string SignatureSha256 { get { return _installers.SignatureSha256; } }

		public string InstallerType { get { return _installers.InstallerType; } }

		public string InstallerLocale { get { return _installers.InstallerLocale; } }

		public string Scope { get { return _installers.Scope; } }

		public DateTime? ReleaseDate { get { return _installers.ReleaseDate; } }


		public string ProductCode { get { return _installers.ProductCode; } }
		public string UpgradeBehavior { get { return _installers.UpgradeBehavior; } }

		//public ManifestSwitches Switches { get { return _installers.Switches; } }


		public string SwitchesSilent { get { return _installers.InstallerSwitches?.Silent; } }

		public string SwitchesSilentWithProgress { get { return _installers.InstallerSwitches?.SilentWithProgress; } }

		public string SwitchesCustom { get { return _installers.InstallerSwitches?.Custom; } }

		public string SwitchesInstallLocation { get { return _installers.InstallerSwitches?.InstallLocation; } }

		public string SwitchesLanguage { get { return _installers.InstallerSwitches?.Language; } }

		public string SwitchesLog { get { return _installers.InstallerSwitches?.Log; } }
		public string SwitchesInteractive { get { return _installers.InstallerSwitches?.Interactive; } }

	}
}
