using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatChannelMaster : WebAPI
	{
		public ReqChatChannelMaster()
		{
			this.name = "chat/channel/master";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
