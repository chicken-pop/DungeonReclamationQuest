using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyominoUserControlLidMaker : MonoBehaviour
{
    public Sprite DungeonLidSprite;

    /// <summary>
    /// User‚ª‘€ì‚·‚éƒ|ƒŠƒIƒ~ƒm‚Ì¶¬
    /// </summary>
    public void UserControlDungeonLidMake()
    {
        if(transform.childCount > 0 && transform.GetChild(0) != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        var polyominoDungeons = Instantiate(AssetsLoad.Instance.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);

        polyominoDungeons.GetComponent<Dungeons>().enabled = false;

        polyominoDungeons.name = "UserControlLids";

        foreach (var userControlPolyominoRenderer in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            userControlPolyominoRenderer.sprite = DungeonLidSprite;
            userControlPolyominoRenderer.sortingOrder = 1;
        }

        foreach (var userControlPolyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
        {
            userControlPolyomino.GetPolyominoCollider.size *= 0.6f;
        }
    }
}
