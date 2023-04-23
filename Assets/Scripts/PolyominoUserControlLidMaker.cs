using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyominoUserControlLidMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonLidSprite;

    /// <summary>
    /// User‚ª‘€ì‚·‚éƒ|ƒŠƒIƒ~ƒm‚Ì¶¬
    /// </summary>
    public void UserControlDungeonLidMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);

        foreach (var userControlPolyomino in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            userControlPolyomino.sprite = DungeonLidSprite;
        }
    }
}
