using Android.Content;
using Android.Net;
using Android.OS;
using Java.IO;
using Java.Lang;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid;
using MvvmCross.Platform.Platform;
using PreHoneyCombClipboardManager = Android.Text.ClipboardManager;

#pragma warning disable CS0618 // Type or member is obsolete
namespace Clipboard.Droid
{
	public class ClipboardService : IClipboardService
	{
		internal static void Initialize() => Mvx.RegisterSingleton<IClipboardService>(new ClipboardService());

		private ClipboardService() { }

		public Context ApplicationContext => Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext;

		public bool CopyToClipboard(string text)
		{
			try
			{
				var clipboardService = ApplicationContext.GetSystemService(Context.ClipboardService);

				if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				{
					var clipboard = (ClipboardManager)clipboardService;
					clipboard.PrimaryClip = ClipData.NewPlainText("", text);
				}
				else
				{
					var clipboard = (PreHoneyCombClipboardManager)clipboardService;
					clipboard.Text = text;
				}

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
				var clipboardService = ApplicationContext.GetSystemService(Context.ClipboardService);

				if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				{
					var clipboard = (ClipboardManager)clipboardService;

					var resolver = ApplicationContext.ContentResolver;

					var item = clipboard.PrimaryClip?.GetItemAt(0);
					var text = ReadClipboardItem(item);

					return text;
				}
				else
				{
					var clipboard = (PreHoneyCombClipboardManager)clipboardService;
					return clipboard.Text;
				}
			}
			catch (Exception ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, "Failed to copy text to clipboard with error {0} ", ex);
			}

			return "";
		}

		private string ReadClipboardItem(ClipData.Item item)
		{
			var context = ApplicationContext;

			if (item == null) return "";

			var text = item.Text;
			if (text != null) return text;

			var uri = item.Uri;
			if (uri != null) return ReadInfoFromUri(context, uri);

			var intent = item.Intent;
			if (intent != null) return intent.ToUri(Intent.UriIntentScheme);

			return "";
		}

		private string ReadInfoFromUri(Context context, Uri uri)
		{
			try
			{
				var descr = context.ContentResolver.OpenTypedAssetFileDescriptor(uri, "text/*", null);
				using (var stream = descr.CreateInputStream())
				{
					var reader = new InputStreamReader(stream, "UTF-8");

					var builder = new StringBuilder(128);
					char[] buffer = new char[8192];
					int len;
					while ((len = reader.Read(buffer)) > 0)
					{
						builder.Append(buffer, 0, len);
					}

					return builder.ToString();
				}
			}
			catch (FileNotFoundException) { }
			catch (IOException ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, "Failure loading text from ClipData with error {0}", ex.Message);
			}

			return uri.ToString();
		}
	}
}
#pragma warning restore CS0618 // Type or member is obsolete