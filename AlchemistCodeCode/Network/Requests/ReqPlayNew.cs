using GR;
using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqPlayNew : WebAPI
	{
		public ReqPlayNew(bool isDebug)
		{
			this.name = "playnew";
			this.body = string.Empty;
			string text = string.Empty;
			if (isDebug)
			{
				text = "\"debug\":1,";
			}
			text = text + "\"permanent_id\":\"" + GameManager.Instance.UdId + "\"";
			this.body += WebAPI.GetRequestString(text);
		}
	}
}
