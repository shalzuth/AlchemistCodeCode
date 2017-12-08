using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemShopBuypaid : WebAPI
	{
		public ReqItemShopBuypaid(string iname, int id)
		{
			this.name = "shop/buy";
			this.body = "\"iname\":\"" + iname + "\",";
			this.body = this.body + "\"id\":" + id.ToString();
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
