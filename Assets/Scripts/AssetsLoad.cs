using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsLoad : MonoBehaviour
{
    public List<string> keys = new List<string>();
    AsyncOperationHandle<IList<GameObject>> opHandle;

    public string Labels;

    public List<GameObject> LoadedDungeons;

    public bool AssetLoad = false;

    public IEnumerator LoadDungeons()
    {
        opHandle = Addressables.LoadAssetsAsync<GameObject>
            (Labels,
            /*
                obj =>
                {
                    Debug.Log(obj.name);
                },
                Addressables.MergeMode.Union
            */
                null
            );

        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            for (int i = 0; i < opHandle.Result.Count; i++)
            {
                LoadedDungeons.Add(opHandle.Result[i]);
            }
            AssetLoad = true;

        }
    }

    void OnDestroy()
    {
        Addressables.Release(opHandle);
    }

}
