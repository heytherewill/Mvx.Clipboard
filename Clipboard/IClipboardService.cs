namespace Clipboard
{
	public interface IClipboardService
	{
        /// <summary>
        /// Copy a string into the clipboard
        /// Wpf : Do not forget to add [STAThread()] on your method
        /// </summary>
        /// <param name="text">text to copy</param>
        /// <returns></returns>
		bool CopyToClipboard(string text);

        /// <summary>
        /// Get string from the clipboard
        /// </summary>
        /// <returns></returns>
		string ReadFromClipboard();
	}
}