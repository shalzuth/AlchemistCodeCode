using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusMake : WebAPI
	{
		public class Response
		{
			public string token;

			public string owner_name;

			public int roomid;
		}

		public ReqVersusMake(VERSUS_TYPE type, string comment, string iname, bool isLine = false)
		{
			this.name = "vs/" + type.ToString().ToLower() + "match/make";
			this.body = string.Empty;
			this.body = this.body + "\"comment\":\"" + JsonEscape.Escape(comment) + "\",";
			this.body = this.body + "\"iname\":\"" + JsonEscape.Escape(iname) + "\",";
			this.body = this.body + "\"Line\":" + ((!isLine) ? 0 : 1);
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
