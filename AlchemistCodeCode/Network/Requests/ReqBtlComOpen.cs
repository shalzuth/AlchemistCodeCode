using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComOpen : WebAPI
	{
		public ReqBtlComOpen(string iname)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "btl/com/open";
			stringBuilder.Append("\"areaid\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
