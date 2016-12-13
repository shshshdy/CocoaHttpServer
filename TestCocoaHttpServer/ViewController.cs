using System;
using System.Diagnostics;
using System.IO;
using CocoaHttpServer;
using Foundation;
using UIKit;
using WebKit;

namespace TestCocoaHttpServer
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		static HTTPServer server;
		WKWebView webview;
		NSString serverPort;
		public ViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidAppear(bool animated)
		{
			RegisterServer();

			base.ViewDidAppear(animated);
		}

		private void RegisterServer()
		{
			NSError error;

			if (null == server)
			{
				var config = new WKWebViewConfiguration();
				webview = new WKWebView(UIScreen.MainScreen.Bounds, config);
				this.View.Add(webview);
				var path = Path.Combine(NSBundle.MainBundle.BundlePath, "Html");

				string serverUrl = "";
				server = new HTTPServer();
				server.Init();
				server.SetType("_http._tcp.");
				server.SetInterface("127.0.0.1");
				server.SetDocumentRoot(path);

				if (!server.Start(out error, (ip, port) =>
				{
					serverPort = port;
					serverUrl = $"http://127.0.0.1:{port}";
					Debug.Print("server start:" + serverUrl);
					webview.LoadRequest(new NSUrlRequest(new NSUrl(serverUrl)));
				}))
				{
					Debug.Print(error.ToString());
				}
			}
			else {
				if (!server.IsRunning())
				{
					server.SetPort(ushort.Parse(serverPort.ToString()));
					server.Start(out error, null);
				}
			}
		}
	}

}

