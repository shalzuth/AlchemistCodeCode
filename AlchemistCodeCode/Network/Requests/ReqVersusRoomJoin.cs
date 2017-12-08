using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusRoomJoin : WebAPI
	{
		public class Quest
		{
			public string iname;
		}

		public class Response
		{
			public string app_id;

			public string token;

			public ReqVersusRoomJoin.Quest quest;
		}

		public ReqVersusRoomJoin(int roomID)
		{
			this.name = "vs/friendmatch/join";
			this.body = string.Empty;
			this.body = this.body + "\"roomid\":" + roomID;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
