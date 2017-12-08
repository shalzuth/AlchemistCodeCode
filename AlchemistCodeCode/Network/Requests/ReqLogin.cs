using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqLogin : WebAPI
	{
		public ReqLogin()
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"device\":\"");
            //stringBuilder.Append("samsung SM-E7000");
            stringBuilder.Append("iPhoneUnknown");
            stringBuilder.Append("\"");
			this.name = "login";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
