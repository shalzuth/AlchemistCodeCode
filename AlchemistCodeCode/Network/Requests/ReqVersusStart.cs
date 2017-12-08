using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusStart : WebAPI
	{
		public class JSON_VersusMap
		{
			public string free;

			public string tower;

			public string friend;
		}

		public class Response
		{
			public string app_id;

			public ReqVersusStart.JSON_VersusMap maps;
		}

		public ReqVersusStart(VERSUS_TYPE type)
		{
			this.name = "vs/start";
			this.body = string.Empty;
			this.body = this.body + "\"type\":\"" + type.ToString().ToLower() + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
