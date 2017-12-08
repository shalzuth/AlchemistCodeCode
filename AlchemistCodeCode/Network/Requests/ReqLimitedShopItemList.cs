using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqLimitedShopItemList : WebAPI
	{
		public ReqLimitedShopItemList(string shop_name)
		{
			this.name = "shop/limited";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"shopName\":\"");
			stringBuilder.Append(shop_name);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
