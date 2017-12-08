using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMultiCheat : WebAPI
	{
		public ReqMultiCheat(int type, string val)
		{
			this.name = "btl/multi/cheat";
			this.body = string.Empty;
			string body = this.body;
			this.body = string.Concat(new object[]
			{
				body,
				"\"type\":",
				type,
				","
			});
			this.body = this.body + "\"val\":\"" + JsonEscape.Escape(val) + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
