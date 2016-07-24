using MvvmCross.Platform.Plugins;

namespace Clipboard.iOS
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			ClipboardService.Initialize();
		}
	}
}