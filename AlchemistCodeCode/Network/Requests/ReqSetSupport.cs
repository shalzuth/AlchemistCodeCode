using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSetSupport : WebAPI
	{
		public ReqSetSupport(long id)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "support/set";
			stringBuilder.Append("\"uiid\":");
			stringBuilder.Append(id);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
