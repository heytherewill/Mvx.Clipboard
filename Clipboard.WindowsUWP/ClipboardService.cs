using System;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Windows.ApplicationModel.DataTransfer;
using System.Threading.Tasks;

#pragma warning disable CS0618 // Type or member is obsolete
namespace Clipboard.WindowsUWP
{
    public class ClipboardService : IClipboardService
	{
		internal static void Initialize() => Mvx.RegisterSingleton<IClipboardService>(new ClipboardService());

        internal ClipboardService() { }
        
		public bool CopyToClipboard(string text)
		{
			try
			{
                var dataPackage = new DataPackage();
                dataPackage.SetText(text);
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);

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
                var dataPackage = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
                if (dataPackage.Contains(StandardDataFormats.Text))
                {
                    var textTask = Task.Run(async () =>
                    {
                        return await dataPackage.GetTextAsync();
                    });
                    textTask.Wait();
                    return textTask.Result;
                }
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