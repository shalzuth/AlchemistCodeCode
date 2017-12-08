using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactFavorite : WebAPI
	{
		public ReqArtifactFavorite(long iid, bool isFavorite)
		{
			this.name = "unit/job/artifact/favorite";
			this.body = WebAPI.GetRequestString(string.Concat(new object[]
			{
				"\"iid\":",
				iid,
				",\"fav\":",
				(!isFavorite) ? 0 : 1
			}));
		}
	}
}
