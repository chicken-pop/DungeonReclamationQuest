using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEnemyParameterManager : MonoBehaviour
{
    public float SetenemyAttackPoint
    {
        set { enemyAttackPoint= value; }
    }

    public float GetEnemyAttackPoint
    {
        get { return enemyAttackPoint; }
    }

    private float enemyAttackPoint = 1;
}
