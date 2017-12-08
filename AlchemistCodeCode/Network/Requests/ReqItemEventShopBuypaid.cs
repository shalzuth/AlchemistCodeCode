using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemEventShopBuypaid : WebAPI
	{
		public ReqItemEventShopBuypaid(string shopname, int id, int buynum)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "shop/event/buy";
			stringBuilder.Append("\"shopName\":\"" + shopname + "\",");
			stringBuilder.Append("\"id\":" + id.ToString() + ",");
			stringBuilder.Append("\"buynum\":" + buynum.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
