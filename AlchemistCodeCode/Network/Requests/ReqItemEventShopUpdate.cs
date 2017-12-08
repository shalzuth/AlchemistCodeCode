using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemEventShopUpdate : WebAPI
	{
		public ReqItemEventShopUpdate(string iname, string costiname)
		{
			this.name = "shop/update";
			this.body = "\"iname\":\"" + iname + "\",";
			this.body = this.body + "\"costiname\":\"" + costiname + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
