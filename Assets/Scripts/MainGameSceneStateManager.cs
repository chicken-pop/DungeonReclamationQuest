using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneStateManager : SingletonMonoBehaviour<MainGameSceneStateManager>
{
    public PolyominoDungeonMaker DungeonMaker;
    public PolyominoUserControlLidMaker UserControlLidMaker;
    public AssetsLoad AssetsLoad;

    public MainGameUIManager MainGameUIManager;
    public MainGameUmpire MainGameUmpire;

    /// <summary>
    /// �Q�[���V�[���̃X�e�[�g
    /// </summary>
    public enum GameSceneState
    {
        Invaild,
        Init,
        Ready,
        Start,
        MainGame,
        Result
    }

    private void Start()
    {
        isSceneinSingleton = true;
    }

    public GameSceneState GameSceneStates;

    private void Update()
    {
        switch (GameSceneStates)
        {
            case GameSceneState.Invaild:
                GameSceneStates = GameSceneState.Init;
                break;
            case GameSceneState.Init:
                //���\�[�X�̓ǂݍ���
                StartCoroutine(AssetsLoad.LoadDungeons());
                //���\�[�X�҂��̃��[�_����\������
                StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal());
                GameSceneStates = GameSceneState.Ready;
                break;
            case GameSceneState.Ready:
                if (AssetsLoad.AssetLoad)
                {
                    DungeonMaker.DungeonMake();
                    UserControlLidMaker.UserControlDungeonLidMake();
                    GameSceneStates = GameSceneState.Start;
                }
                break;
            case GameSceneState.Start:
                if (MainGameUmpire.isReady)
                {
                    MainGameUIManager.InitializeUI();
                    GameSceneStates = GameSceneState.MainGame;
                }
                break;
            case GameSceneState.MainGame:

                break;
            case GameSceneState.Result:

                break;


        }
    }
}
