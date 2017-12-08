using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemLimitedShopBuypaid : WebAPI
	{
		public ReqItemLimitedShopBuypaid(string shopname, int id, int buynum)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "shop/limited/buy";
			stringBuilder.Append("\"shopName\":\"" + shopname + "\",");
			stringBuilder.Append("\"id\":" + id.ToString() + ",");
			stringBuilder.Append("\"buynum\":" + buynum.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
