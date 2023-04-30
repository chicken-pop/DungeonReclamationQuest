using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEnemyTimer : MonoBehaviour
{
    public float enemyTimer;
    //private float timer;

    private void Update()
    {
        enemyTimer -= Time.deltaTime;

        //Debug.Log(timer);

        /*
        if (enemyTimer <= 0)
        {
            enemyTimer = timer;
            //Debug.Log("¬Œ÷");
        }
        */
    }

}
