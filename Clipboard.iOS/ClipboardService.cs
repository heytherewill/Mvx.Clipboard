using MvvmCross.Platform;
using UIKit;

namespace Clipboard.iOS
{
	public class ClipboardService : IClipboardService
	{
		internal static void Initialize() => Mvx.RegisterSingleton<IClipboardService>(new ClipboardService());

		private ClipboardService() { }

		public bool CopyToClipboard(string text)
		{
			UIPasteboard.General.String = text;
			return false;
		}

		public string ReadFromClipboard()
			=> UIPasteboard.General.String;
	}
}