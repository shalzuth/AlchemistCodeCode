using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatChannelAutoAssign : WebAPI
	{
		public ReqChatChannelAutoAssign()
		{
			this.name = "chat/channel/auto";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
