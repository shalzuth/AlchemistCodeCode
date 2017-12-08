using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatMessageOffical : WebAPI
	{
		public ReqChatMessageOffical()
		{
			this.name = "chat/message/offical";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
