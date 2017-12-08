using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerSupporter : WebAPI
	{
		public ReqTowerSupporter()
		{
			this.name = "tower/supportlist";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
