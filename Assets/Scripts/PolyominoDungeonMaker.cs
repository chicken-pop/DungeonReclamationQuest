using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// ダンジョンの生成
    /// </summary>
    public void DungeonMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            dungeonHole.sprite = DungeonHoleSprite;
        }
    }
}
