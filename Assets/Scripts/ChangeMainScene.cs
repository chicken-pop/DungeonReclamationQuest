using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMainScene : MonoBehaviour
{
    const string sceneName = "MainGame"; 
    public void ChangeMainGameScene()
    {
        DungeonGameSceneManager.Instance.SceneChange(sceneName);
    }
}
