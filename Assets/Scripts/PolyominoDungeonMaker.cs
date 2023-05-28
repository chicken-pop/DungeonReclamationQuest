using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// É_ÉìÉWÉáÉìÇÃê∂ê¨
    /// </summary>
    public void DungeonMake()
    {
        if(transform.childCount > 0 && transform.GetChild(0) != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        var polyominoDungeons = Instantiate(AssetsLoad.Instance.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            dungeonHole.sprite = DungeonHoleSprite;
        }

        foreach (var dungeonPolyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
        {
            dungeonPolyomino.GetPolyominoCollider.isTrigger = true;
            dungeonPolyomino.GetPpolyominoRigidbody2D.isKinematic = true;
            dungeonPolyomino.IsDungeonPolyomino = true;
        }
    }
}
