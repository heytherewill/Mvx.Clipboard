using MvvmCross.Platform.Plugins;

namespace Clipboard.Wpf
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			ClipboardService.Initialize();
		}
	}
}