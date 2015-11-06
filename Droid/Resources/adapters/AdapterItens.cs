using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MeusPedidos.Droid
{
	public class AdapterItens : BaseAdapter {

		List<ItemPedido> items;
		Activity context;

		public AdapterItens(Activity context, List<ItemPedido> items) : base() {
			this.context = context;
			this.items = items;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override int Count {
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {
			ItemPedido item = items [position];
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.Item, null);
			view.FindViewById<TextView>(Resource.Id.tv_nome).Text = item.Nome;
			view.FindViewById<TextView>(Resource.Id.tv_quantidade).Text = item.Quantidade.ToString();
			view.FindViewById<TextView>(Resource.Id.tv_preco).Text = item.Preco.ToString();
			return view;
		}

	}
}

