using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMultiRank : WebAPI
	{
		public class Json_MultiRankParam
		{
			public string unit_iname;

			public string job_iname;
		}

		public class Json_MultiRank
		{
			public ReqMultiRank.Json_MultiRankParam[] ranking;

			public int isReady;
		}

		public ReqMultiRank(string iname)
		{
			this.name = "btl/usedunit";
			this.body = "\"iname\":\"" + JsonEscape.Escape(iname) + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
