using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGetSupport : WebAPI
	{
		public ReqGetSupport()
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "support";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
