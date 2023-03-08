#if WINDOWS
using Microsoft.UI;
using.Microsoft.UI.Windowing;
using.Microsoft.Graphics;
#endif


namespace SientificKalklaator;

public partial class App : Application
{
	const int WindowWidth = 540;
	const int WindowHeight = 1000;


	public App()
	{
		InitializeComponent();

		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (Handler, view) =>
		{
#if WINDOWS
			var mauiWindow = Handler.VirtualView;
			var nativeWindow = Handler.PlatformView;
			nativeWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
#endif

		});
		MainPage = new CalculatorPage();
	}
}
