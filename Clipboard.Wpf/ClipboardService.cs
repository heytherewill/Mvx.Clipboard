using System;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

#pragma warning disable CS0618 // Type or member is obsolete
namespace Clipboard.Wpf
{
    public class ClipboardService : IClipboardService
	{
		internal static void Initialize() => Mvx.RegisterSingleton<IClipboardService>(new ClipboardService());

        internal ClipboardService() { }
        
		public bool CopyToClipboard(string text)
		{
			try
			{
                System.Windows.Forms.Clipboard.SetText(text);

                return true;
			}
			catch (Exception ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, "Failed to copy text to clipboard with error {0} ", ex);
			}

			return false;
		}

		public string ReadFromClipboard()
		{
			try
            {
                return System.Windows.Forms.Clipboard.GetText();
            }
			catch (Exception ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, "Failed to copy text to clipboard with error {0} ", ex);
			}

			return "";
		}
	}
}
#pragma warning restore CS0618 // Type or member is obsolete