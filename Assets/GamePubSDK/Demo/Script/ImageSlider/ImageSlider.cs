using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace GamePub.PubSDK
{
	/// <summary>
	/// Creates banners and paginator by given banner list.
	/// </summary>
	public class ImageSlider : MonoBehaviour
	{
		[Header("Settings")]
		public List<Banner> Banners;
		public bool Random;
		public bool Elastic = true;

		[Header("UI")]
		public Transform BannerGrid;
		public Button BannerPrefab;
		public Transform PaginationGrid;
		public Toggle PagePrefab;
		public HorizontalScrollSnap HorizontalScrollSnap;

		public void OnValidate()
		{
			GetComponent<ScrollRect>().content.GetComponent<GridLayoutGroup>().cellSize = GetComponent<RectTransform>().sizeDelta;
		}

		public IEnumerator Start()
		{
			foreach (Transform child in BannerGrid)
			{
				Destroy(child.gameObject);
			}

			foreach (Transform child in PaginationGrid)
			{
				Destroy(child.gameObject);
			}

			foreach (var banner in Banners)
			{
				var instance = Instantiate(BannerPrefab, BannerGrid);
				var button = instance.GetComponent<Button>();

				button.onClick.RemoveAllListeners();

				if (string.IsNullOrEmpty(banner.Url))
				{
					button.enabled = false;
				}
				else
				{
					button.onClick.AddListener(() => { Application.OpenURL(banner.Url); });
				}
				
				StartCoroutine(Downloader(instance, banner.imageUrl));

				if (Banners.Count > 1)
				{
					var toggle = Instantiate(PagePrefab, PaginationGrid);

					toggle.group = PaginationGrid.GetComponent<ToggleGroup>();
				}
			}

			yield return null;

			HorizontalScrollSnap.Initialize(Random);
			HorizontalScrollSnap.GetComponent<ScrollRect>().movementType = Elastic ? ScrollRect.MovementType.Elastic : ScrollRect.MovementType.Clamped;
		}

		IEnumerator Downloader(Button go,string url)
		{
			if (url != null)
			{
				var www = UnityWebRequestTexture.GetTexture(url);
				yield return www.SendWebRequest();
				if (www.isNetworkError || www.isHttpError)
				{
					Debug.LogError(www.error);
				}
				else
				{
					var texture = DownloadHandlerTexture.GetContent(www);
					go.GetComponent<Image>().color = Color.white;
					go.GetComponent<Image>().sprite = Sprite.Create(
						texture,
						new Rect(0, 0, texture.width, texture.height),
						new Vector2(0.5f, 0.5f));
				}
			}
			else
			{
				yield return null;
			}
		}
	}
}