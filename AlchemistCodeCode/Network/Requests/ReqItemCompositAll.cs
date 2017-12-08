using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemCompositAll : WebAPI
	{
		public ReqItemCompositAll(string iname)
		{
			this.name = "item/gouseiall";
			this.body = WebAPI.GetRequestString("\"iname\":\"" + iname + "\"");
		}
	}
}
