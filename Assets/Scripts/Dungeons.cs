using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dungeons : MonoBehaviour
{
    private List<Polyomino> polyominos = new List<Polyomino>();

    public bool IsBulid = false;

    private void Start()
    {
        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            polyominos.Add(polyomino);
        }
    }

    private void Update()
    {
        //Polyominos�����ׂĖ��܂��Ă�����
         IsBulid = polyominos.All(polyomino => polyomino.IsBuried);
        if (IsBulid)
        {
           Debug.Log("�N���A");
        }
    }
}
