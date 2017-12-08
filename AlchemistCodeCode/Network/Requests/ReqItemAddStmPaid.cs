using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemAddStmPaid : WebAPI
	{
		public ReqItemAddStmPaid()
		{
			this.name = "item/addstmpaid";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
