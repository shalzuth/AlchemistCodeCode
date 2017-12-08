using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGAuthPasscode : WebAPI
	{
		public ReqGAuthPasscode(string secretKey, string deviceID)
		{
			this.name = "gauth/passcode";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"secret_key\":\"");
			stringBuilder.Append(secretKey);
			stringBuilder.Append("\",\"device_id\":\"");
			stringBuilder.Append(deviceID);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
