using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUpdateSelectAward : WebAPI
	{
		public ReqUpdateSelectAward(string iname)
		{
			this.name = "award/select";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"selected_award\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
