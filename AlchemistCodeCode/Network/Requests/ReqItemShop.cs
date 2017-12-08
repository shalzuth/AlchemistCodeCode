using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemShop : WebAPI
	{
		public ReqItemShop(string iname)
		{
			this.name = "shop";
			this.body = WebAPI.GetRequestString("\"iname\":\"" + iname + "\"");
		}
	}
}
