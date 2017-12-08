using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComReset : WebAPI
	{
		public ReqBtlComReset(string iname)
		{
			this.name = "btl/com/reset";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iname\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
