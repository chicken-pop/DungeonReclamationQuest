using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUmpire : SingletonMonoBehaviour<MainGameUmpire>
{
    private MainGamePlayer mainGamePlayer;

    public MainGamePlayer SetMainGamePlayer
    {
        set { mainGamePlayer = value; }
    }

    public MainGamePlayer GetMainGamePlayer
    {
        get { return mainGamePlayer; }
    }

    //•¡”‚Ì“G‚ğÀ‘•
    private List<MainGameEnemy> mainGameEnemies =  new List<MainGameEnemy>();

    public MainGameEnemy SetMainGameEnemy
    {
        set { mainGameEnemies.Add(value); }
    }

    public List<MainGameEnemy> GetMainGameEnemies
    {
        get { return mainGameEnemies; }
    }
    public bool isReady =false;

    private void Start()
    {
        isSceneinSingleton = true;
        MainGameSceneStateManager.Instance.MainGameUmpire = this;
    }

    private void Update()
    {
        if (isReady)
        {
            return;
        }

        if(GetMainGamePlayer != null && mainGameEnemies.Count > 0)
        {
            isReady = true;
        }
    }

}
