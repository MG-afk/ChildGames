using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Dream.Core
{
	public static class SpriteLoader
	{
		public static async Task<Sprite> LoadSpriteAsync(string addressableKey)
		{
			var handle = Addressables.LoadAssetAsync<Sprite>(addressableKey);
			await handle.Task;

			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				return handle.Result;
			}
			else
			{
				//Debug.LogError($"Failed to load sprite with key: {addressableKey}");
				return null;
			}
		}

		public static void ReleaseSprite(Sprite sprite)
		{
			Addressables.Release(sprite);
		}
	}
}