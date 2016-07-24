namespace Clipboard
{
	public interface IClipboardService
	{
		bool CopyToClipboard(string text);

		string ReadFromClipboard();
	}
}