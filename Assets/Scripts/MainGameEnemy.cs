using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainGameEnemyTimer))]
[RequireComponent(typeof(MainGameEnemyParameterManager))]
public class MainGameEnemy : MonoBehaviour
{
    private MainGameEnemyTimer mainGameEnemyTimer => GetComponent<MainGameEnemyTimer>();
    private MainGameEnemyParameterManager mainGameEnemyParameterManager => GetComponent<MainGameEnemyParameterManager>();

    public void EnemyAttack()
    {
        MainGameUmpire.Instance.GetMainGamePlayer.Damage(mainGameEnemyParameterManager.GetEnemyAttackPoint);
    }

    private void Update()
    {
        if(mainGameEnemyTimer.enemyTimer < 0)
        {
            EnemyAttack();

            mainGameEnemyTimer.enemyTimer = 3f;
        }
    }
}
