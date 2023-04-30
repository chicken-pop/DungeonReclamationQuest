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
        var rand = Random.Range(0, this.transform.GetComponentsInChildren<Polyomino>().Count());
        var count = 0;

        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            if (rand == count)
            {
                Instantiate(MainGameEnemy.gameObject, polyomino.transform);
            }
            count++;
            polyominos.Add(polyomino);
        }
    }

    private void Update()
    {
        //PolyominosÇ™Ç∑Ç◊ÇƒñÑÇ‹Ç¡ÇƒÇ¢ÇΩÇÁ
        IsBulid = polyominos.All(polyomino => polyomino.IsBuried);
        if (IsBulid)
        {
            Debug.Log("ÉNÉäÉA");
        }
    }
}
