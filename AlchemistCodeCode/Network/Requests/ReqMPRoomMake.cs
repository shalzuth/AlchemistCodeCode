using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMPRoomMake : WebAPI
	{
		public class Response
		{
			public int roomid;

			public string app_id;

			public string token;
		}

		public ReqMPRoomMake(string iname, string comment, string passCode, bool isPrivate)
		{
			this.name = "btl/room/make";
			this.body = string.Empty;
			this.body = this.body + "\"iname\":\"" + JsonEscape.Escape(iname) + "\"";
			this.body = this.body + ",\"comment\":\"" + JsonEscape.Escape(comment) + "\"";
			this.body = this.body + ",\"pwd\":\"" + JsonEscape.Escape(passCode) + "\"";
			this.body = this.body + ",\"private\":" + ((!isPrivate) ? 0 : 1);
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
