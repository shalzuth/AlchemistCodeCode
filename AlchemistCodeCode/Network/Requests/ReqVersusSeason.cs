using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusSeason : WebAPI
	{
		public class Response
		{
			public int unreadmail;
		}

		public ReqVersusSeason()
		{
			this.name = "vs/towermatch/season";
			this.body = string.Empty;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
