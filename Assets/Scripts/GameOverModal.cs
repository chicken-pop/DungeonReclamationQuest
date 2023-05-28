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

        var returnStartSceneButton = new ButtonAction
        {
            ButtonText = "スタートへ",
            Action = GameOverTransition
        };

         var reStartButton = new ButtonAction
        {
            ButtonText = "続き",
            Action = NextGameOverTransition
        };

        ButtonModalInitialize(returnStartSceneButton, reStartButton);
    }

    public void GameOverTransition()
    {
        MainGameSceneConfigManager.Instance.Level = 1;
        DungeonGameSceneManager.Instance.SceneChange(DungeonGameSceneManager.GameStartSceneName);
        CloseButtonModal();
    }

    public void NextGameOverTransition()
    {
        DungeonGameSceneManager.Instance.SceneChange(DungeonGameSceneManager.GameMainSceneName);
        this.gameObject.SetActive(false);
    }
}
