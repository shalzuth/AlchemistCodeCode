using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqLoginPack : WebAPI
	{
		public ReqLoginPack()
		{
			this.name = "login/param";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
