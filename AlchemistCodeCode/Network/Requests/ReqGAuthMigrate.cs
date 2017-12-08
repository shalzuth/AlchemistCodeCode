using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGAuthMigrate : WebAPI
	{
		public ReqGAuthMigrate(string secretKey, string deviceID, string passcode)
		{
			this.name = "gauth/migrate";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"secret_key\":\"");
			stringBuilder.Append(secretKey);
			stringBuilder.Append("\",\"device_id\":\"");
			stringBuilder.Append(deviceID);
			stringBuilder.Append("\",\"passcode\":\"");
			stringBuilder.Append(passcode);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
