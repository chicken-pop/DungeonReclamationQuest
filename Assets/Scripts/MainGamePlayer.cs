using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainGamePlayerParameterManager))]
public class MainGamePlayer : MonoBehaviour
{
    private MainGamePlayerParameterManager mainGamePlayerParameterManager => GetComponent<MainGamePlayerParameterManager>();

    public bool IsDead = false;

    public void Damage(float damagePoint)
    {
        if(damagePoint > 0)
        {
            var currentHitPoint = mainGamePlayerParameterManager.GetHitPoint;
            currentHitPoint -= damagePoint;
            mainGamePlayerParameterManager.SetHitpoint =currentHitPoint;
        }
    }

    private void Start()
    {
        MainGameUmpire.Instance.SetMainGamePlayer = this;
    }

    private void Update()
    {
        if(mainGamePlayerParameterManager.GetHitPoint < 0)
        {
            if (!IsDead)
            {
                IsDead = true;
            }
        }
    }

}
