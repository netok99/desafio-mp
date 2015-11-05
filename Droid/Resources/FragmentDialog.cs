
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MeusPedidos.Droid {


	public class OnDialogEventArgs : EventArgs {

		private string nome;
		private string quantidade;
		private string preco;

		public string Nome { 
			get{ return nome; }
			set{ nome = value; }
		}
		public string Preco {
			get{ return quantidade; } 
			set{ quantidade = value; } 
		}
		public string Quantidade {
			get{ return quantidade; } 
			set{ quantidade = value;} 
		}

		public OnDialogEventArgs( string nome, string preco, string quantidade) {
			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
		}
	}

	public class FragmentDialog : DialogFragment {
		private EditText et_nome;
		private EditText et_preco;
		private EditText et_quantidade;
		private Button adicionar;

//		public override void OnCreate (Bundle savedInstanceState){
//			base.OnCreate (savedInstanceState);
//		}

		public event EventHandler<OnDialogEventArgs> dialogComplete; 

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.dialog_item, container, false);

			et_nome = view.FindViewById<EditText> (Resource.Id.et_nome);
			et_quantidade = view.FindViewById<EditText> (Resource.Id.et_quantidade);
			et_preco = view.FindViewById<EditText> (Resource.Id.et_preco);
			adicionar = view.FindViewById<Button> (Resource.Id.bt_adicionar);

			adicionar.Click += (object sender, EventArgs e) => {
				dialogComplete.Invoke(this, new OnDialogEventArgs(et_nome.Text, et_quantidade.Text, et_preco.Text));
				this.Dismiss();
			};

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState) {
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
//			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
		}
	}

}

