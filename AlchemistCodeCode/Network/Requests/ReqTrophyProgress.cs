using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTrophyProgress : WebAPI
	{
		public ReqTrophyProgress()
		{
			this.name = "trophy";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
