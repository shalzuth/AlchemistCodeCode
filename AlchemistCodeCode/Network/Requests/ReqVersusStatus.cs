using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusStatus : WebAPI
	{
		public class Response
		{
			public int floor;

			public int key;

			public int wincnt;

			public int is_season_gift;

			public int is_give_season_gift;

			public long end_at;

			public string vstower_id;

			public string tower_iname;
		}

		public ReqVersusStatus()
		{
			this.name = "vs/status";
			this.body = string.Empty;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
