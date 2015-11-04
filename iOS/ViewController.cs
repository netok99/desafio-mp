using System;
		
using UIKit;

namespace MeusPedidos.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{		
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif

//			// Perform any additional setup after loading the view, typically from a nib.
//			Button.AccessibilityIdentifier = "myButton";
//			Button.TouchUpInside += delegate {
//				var title = string.Format ("{0} clicks!", count++);
//				Button.SetTitle (title, UIControlState.Normal);
//			};

			cliqueAqui.TouchUpInside += (object sender, EventArgs e) => {
				var alert = UIAlertController.Create ("Hello World", "Olá " + nome.Text, UIAlertControllerStyle.Alert);  
				alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
				PresentViewController (alert, true, null);	
			};
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
