using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBingoProgress : WebAPI
	{
		public ReqBingoProgress()
		{
			this.name = "bingo";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
