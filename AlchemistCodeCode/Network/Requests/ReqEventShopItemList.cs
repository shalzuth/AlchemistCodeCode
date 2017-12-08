using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqEventShopItemList : WebAPI
	{
		public ReqEventShopItemList(string shop_name)
		{
			this.name = "shop/event";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"shopName\":\"");
			stringBuilder.Append(shop_name);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
