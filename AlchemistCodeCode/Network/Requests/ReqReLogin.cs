using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqReLogin : WebAPI
	{
		public ReqReLogin(int ymd)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"yymmdd\":");
			stringBuilder.Append(ymd);
			this.name = "login/span";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
