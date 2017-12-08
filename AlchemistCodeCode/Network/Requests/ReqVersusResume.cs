using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusResume : WebAPI
	{
		public class Quest
		{
			public string iname;
		}

		public class Response
		{
			public ReqVersusResume.Quest quest;

			public int btlid;

			public string app_id;

			public string token;

			public string type;

			public Json_BtlInfo_Multi btlinfo;
		}

		public ReqVersusResume(long btlID)
		{
			this.name = "vs/resume";
			this.body = string.Empty;
			this.body = this.body + "\"btlid\":" + btlID;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
