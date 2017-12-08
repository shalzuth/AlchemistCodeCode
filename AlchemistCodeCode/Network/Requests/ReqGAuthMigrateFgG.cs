using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGAuthMigrateFgG : WebAPI
	{
		public ReqGAuthMigrateFgG(string secretKey, string deviceID, string mail, string password)
		{
			this.name = "gauth/achievement/mgrate";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"secret_key\":\"");
			stringBuilder.Append(secretKey);
			stringBuilder.Append("\",\"device_id\":\"");
			stringBuilder.Append(deviceID);
			stringBuilder.Append("\",\"email\":\"");
			stringBuilder.Append(mail);
			stringBuilder.Append("\",\"password\":\"");
			stringBuilder.Append(password);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
