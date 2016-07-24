# Mvx.Clipboard
📋 MvvmCross plugin to access the device's clipboard

# Installation

Install via [NuGet](https://www.nuget.org/packages/Mvx.Clipboard/) using:

``PM> Install-Package Mvx.Clipboard``

# Usage

Resolve it:

``var clipboardService = Mvx.Resolve<IClipboardService>();``

Set clipboard data:

```
var success = clipboardService.CopyToClipboard("Some text");
```

Get data from clipboard:

``var clipboardContent = clipboardService.ReadFromClipboard();;``

#Thanks

Clipboard icon by Andrew Onorato from the Noun Project
