using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameSceneManager : SingletonMonoBehaviour<DungeonGameSceneManager>
{
    public const string GameStartSceneName = "Title";
    public const string GameMainSceneName = "MainGame";

    public void SceneChange(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

}
