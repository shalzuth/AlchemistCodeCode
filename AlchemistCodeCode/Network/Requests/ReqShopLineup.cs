using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqShopLineup : WebAPI
	{
		public ReqShopLineup(string shop_name)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "shop/itemlist";
			stringBuilder.Append("\"shopName\":\"");
			stringBuilder.Append(shop_name);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
