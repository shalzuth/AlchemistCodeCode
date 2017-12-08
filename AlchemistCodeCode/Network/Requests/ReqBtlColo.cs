using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlColo : WebAPI
	{
		public ReqBtlColo()
		{
			this.name = "btl/colo";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
