using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMultiPlayResume : WebAPI
	{
		public class Quest
		{
			public string iname;
		}

		public class Response
		{
			public ReqMultiPlayResume.Quest quest;

			public int btlid;

			public string app_id;

			public string token;

			public Json_BtlInfo_Multi btlinfo;
		}

		public ReqMultiPlayResume(long btlID)
		{
			this.name = "btl/multi/resume";
			this.body = string.Empty;
			this.body = this.body + "\"btlid\":" + btlID;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
