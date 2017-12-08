using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemShopUpdate : WebAPI
	{
		public ReqItemShopUpdate(string iname)
		{
			this.name = "shop/update";
			this.body = "\"iname\":\"" + iname + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
