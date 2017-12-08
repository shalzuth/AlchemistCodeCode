using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusRoomUpdate : WebAPI
	{
		public ReqVersusRoomUpdate(int roomID, string comment, string iname)
		{
			this.name = "vs/friendmatch/update";
			this.body = string.Empty;
			this.body = this.body + "\"roomid\":" + roomID;
			this.body = this.body + ",\"comment\":\"" + JsonEscape.Escape(comment) + "\"";
			this.body = this.body + ",\"quest\":\"" + iname + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
