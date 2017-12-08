using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFgGAuth : WebAPI
	{
		public enum eAuthStatus
		{
			None,
			Disable,
			NotSynchronized,
			Synchronized
		}

		public ReqFgGAuth()
		{
			this.name = "achieve/auth";
		}
	}
}
