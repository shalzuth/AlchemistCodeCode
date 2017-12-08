using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqAlterCheck : WebAPI
	{
		public ReqAlterCheck(string hash)
		{
			this.name = "altercheck";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("hash");
			stringBuilder.Append(hash);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
