using MvvmCross.Platform.Plugins;

namespace Clipboard.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			ClipboardService.Initialize();
		}
	}
}