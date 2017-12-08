using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSetLanguage : WebAPI
	{
		public ReqSetLanguage(string language)
		{
			string str = language;
			this.name = "setlanguage";
			this.body = WebAPI.GetRequestString("\"lang\":\"" + str + "\"");
		}
	}
}
