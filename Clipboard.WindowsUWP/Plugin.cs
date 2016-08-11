using MvvmCross.Platform.Plugins;

namespace Clipboard.WindowsUWP
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			ClipboardService.Initialize();
		}
	}
}