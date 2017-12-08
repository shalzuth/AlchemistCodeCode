using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMPRoom : WebAPI
	{
		public class Response
		{
			public MultiPlayAPIRoom[] rooms;
		}

		public ReqMPRoom(string fuid)
		{
			this.name = "btl/room";
			this.body = string.Empty;
			if (!string.IsNullOrEmpty(fuid))
			{
				this.body = this.body + "\"fuid\":\"" + JsonEscape.Escape(fuid) + "\"";
			}
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
