using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemComposit : WebAPI
	{
		public ReqItemComposit(string iname)
		{
			this.name = "item/gousei";
			this.body = WebAPI.GetRequestString("\"iname\":\"" + iname + "\"");
		}
	}
}
