using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverModal : ModalBase
{
    public TextMeshProUGUI GameOverText;

    private void Start()
    {
        GameOverText.text = "GameOver...";
        ButtonModalInitialize(GameOverTransition);
    }

    public void GameOverTransition()
    {
        DungeonGameSceneManager.Instance.SceneChange(DungeonGameSceneManager.GameStartSceneName);
    }
}
