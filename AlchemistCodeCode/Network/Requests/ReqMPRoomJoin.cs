using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMPRoomJoin : WebAPI
	{
		public class Quest
		{
			public string iname;
		}

		public class Response
		{
			public string app_id;

			public string token;

			public ReqMPRoomJoin.Quest quest;
		}

		public ReqMPRoomJoin(int roomID, bool LockRoom = false)
		{
			this.name = "btl/room/join";
			this.body = string.Empty;
			string body = this.body;
			this.body = string.Concat(new object[]
			{
				body,
				"\"roomid\":",
				roomID,
				","
			});
			this.body += "\"pwd\":";
			this.body += ((!LockRoom) ? "\"0\"" : "\"1\"");
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
