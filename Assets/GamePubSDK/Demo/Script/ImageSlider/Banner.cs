using System;
using UnityEngine;

namespace GamePub.PubSDK
{
	[Serializable]
	public class Banner
	{
		//public string Name;
		public string Url;
		public string imageUrl;

		public Banner(string url)
        {
			this.imageUrl = url;
        }
	}
}