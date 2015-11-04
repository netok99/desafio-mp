// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MeusPedidos.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton cliqueAqui { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField nome { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (cliqueAqui != null) {
				cliqueAqui.Dispose ();
				cliqueAqui = null;
			}
			if (nome != null) {
				nome.Dispose ();
				nome = null;
			}
		}
	}
}
