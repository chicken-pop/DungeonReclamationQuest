using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamePlayerParameterManager : MonoBehaviour
{
    public float GetHitPoint
    {
        get { return hitPoint;}
    }

    public float SetHitpoint
    {
        set { hitPoint = value; }
    }

    private float hitPoint = 100;

    public void Damage(int damagePoint)
    {
        if(damagePoint > 0)
        {
            hitPoint -= damagePoint;
        }
    }
}
