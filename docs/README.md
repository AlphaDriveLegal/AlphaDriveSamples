# Development with AlphaDrive
The AlphaDrive application framework is a robust engine allowing
users and developers to interact with a virtual file system as well
as the Clio API.

When you start building a new extension for AlphaDrive, there are a
few main classes you should be aware of.  You might not use all of
these but you should pick and choose the ones you need.


| Name | Description 
| --- | --- 
| AlphaDrive.Common.dll
| [AlphaDrive.Application]() | Used for interacting with other extensions.
| [AlphaDrive.StartupExtension]() | All extensions inherit from this.
| [AlphaDrive.StartupExtensionOptionsAttribute]() | Used to configure loading order of an extension.
| [AlphaDrive.SettingsProvider]() | Setting provider for Windows & Mac.
| AlphaDrive.Data.Connectivity.dll
| [AlphaDrive.SharedApiClient]() | Communicate with Clio's API.
| AlphaDrive.WebDav.dll
| [AlphaDrive.Dav.FileSystemObject]() | Base File System Object.
| [AlphaDrive.Dav.FileSystemFile]() | Represents a Virtual File.
| [AlphaDrive.Dav.FileSystemFolder]() | Represents a Virtual Folder
| [AlphaDrive.Dav.ListerSync]() | Base class to list items in a Virtual Folder
| [AlphaDrive.Dav.ListerAsync]() | Base class to list items in a Virtual Folder
| [AlphaDrive.Dav.ListerForAttribute]() | Indicates the folder that a Lister provides items for.
| AlphaDrive.Windows.dll
| [AlphaDrive.InterfaceExtension]() | Base class for extending the UI.
| [AlphaDrive.Windows.Extensions.ControllerDialogExtension]() | The main UI extension.

# Getting started with Windows Development
To get started doing a new windows-based extension for AlphaDrive:
* Create a new WPF Application (this is to get the right dependencies and such)
* Add references to the above DLLs that you intend to use.
* Click on each reference that you added and set "Copy Local" = False.
* From Project Properties, change the project to be a "Class Library".
* From Project Properties, Set your build directory to be the AlphaDrive folder (ie. C:\Users\Tony Valenti\AppData\Local\AlphaDrive\app-2.0.6\)
* From Project Properties, choose Debug > Start External Program > the AlphaDrive EXE(C:\Users\Tony Valenti\AppData\Local\AlphaDrive\app-2.0.6\AlphaDrive.Windows.exe)
* Delete App.xaml, app.config, and MainWindow.xaml (unless you intend to use one of them)
* 