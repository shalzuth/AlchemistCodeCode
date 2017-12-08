using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUnitUnlock : WebAPI
	{
		public ReqUnitUnlock(string iname)
		{
			this.name = "unit/add";
			this.body = WebAPI.GetRequestString("\"iname\":\"" + iname + "\"");
		}
	}
}
