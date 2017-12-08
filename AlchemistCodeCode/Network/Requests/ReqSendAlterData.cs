using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSendAlterData : WebAPI
	{
		public ReqSendAlterData()
		{
			this.name = "master/log";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
