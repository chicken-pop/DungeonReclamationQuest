using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dungeons : MonoBehaviour
{
    private List<Polyomino> polyominos = new List<Polyomino>();

    public bool IsBulid = false;

    public MainGameEnemy MainGameEnemy;

    private void Start()
    {
        var polyominoCount = Random.Range(0, this.transform.GetComponentsInChildren<Polyomino>().Count());
        var enemyCount = Random.Range(1, polyominoCount);

        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            polyominos.Add(polyomino);
        }

        var currentCount = -1;

        //ランダムで何番目のポリオミノに生まれるか計算する
        for (int i = 0; i < enemyCount; i++)
        {
            //3
            var rand = Random.Range(0, polyominoCount);
            if(currentCount != rand)
            {
                currentCount = rand;
            }
            else
            {
                //同じrandが2回導かれた
                rand++;
                if(polyominoCount < rand)
                {
                    rand -= enemyCount;
                    if(rand < 0)
                    {
                        //randが０を下回った場合帰る
                        return;
                    }
                }
            }
            var count = 0;

            foreach (var polyomino in polyominos)
            {
                if(rand == count)
                {
                    var enemy = Instantiate(MainGameEnemy.gameObject, polyomino.transform);

                    foreach (var squarePos in polyomino.GetComponentsInChildren<SpriteRenderer>())
                    {
                        enemy.transform.position = squarePos.transform.position;
                    }
                }
                count++;
            }
        }
    }

    private void Update()
    {
        //Polyominosがすべて埋まっていたら
        IsBulid = polyominos.All(polyomino => polyomino.IsBuried);
        if (IsBulid)
        {
            Debug.Log("クリア");
        }
    }
}
