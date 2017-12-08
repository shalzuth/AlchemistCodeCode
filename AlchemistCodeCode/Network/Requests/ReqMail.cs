using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMail : WebAPI
	{
		public ReqMail(int page, bool isPeriod, bool isRead)
		{
			this.name = "mail";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append(this.MakeKeyValue("page", page));
			stringBuilder.Append(",");
			stringBuilder.Append(this.MakeKeyValue("isPeriod", (!isPeriod) ? 0 : 1));
			stringBuilder.Append(",");
			stringBuilder.Append(this.MakeKeyValue("isRead", (!isRead) ? 0 : 1));
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		private string MakeKeyValue(string key, int value)
		{
			return string.Format("\"{0}\":{1}", key, value);
		}

		private string MakeKeyValue(string key, float value)
		{
			return string.Format("\"{0}\":{1}", key, value);
		}

		private string MakeKeyValue(string key, long value)
		{
			return string.Format("\"{0}\":{1}", key, value);
		}

		private string MakeKeyValue(string key, string value)
		{
			return string.Format("\"{0}\":\"{1}\"", key, value);
		}
	}
}
