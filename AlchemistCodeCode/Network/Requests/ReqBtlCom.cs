using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlCom : WebAPI
	{
		public ReqBtlCom(bool refresh = false)
		{
			this.name = "btl/com";
			if (refresh)
			{
				this.body = WebAPI.GetRequestString("\"event\":1");
			}
			else
			{
				this.body = WebAPI.GetRequestString(null);
			}
		}
	}
}
