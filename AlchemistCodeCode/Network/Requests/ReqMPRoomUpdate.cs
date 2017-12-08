using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMPRoomUpdate : WebAPI
	{
		public ReqMPRoomUpdate(int roomID, string comment, string passCode)
		{
			this.name = "btl/room/update";
			this.body = string.Empty;
			this.body = this.body + "\"roomid\":" + roomID;
			this.body = this.body + ",\"comment\":\"" + JsonEscape.Escape(comment) + "\"";
			this.body = this.body + ",\"pwd\":\"" + JsonEscape.Escape(passCode) + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
