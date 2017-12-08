using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqHikkoshiExec : WebAPI
	{
		public ReqHikkoshiExec(string token)
		{
			this.name = "hikkoshi/exec";
			this.body = WebAPI.GetRequestString("\"token\":\"" + token + "\"");
		}
	}
}
