using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMainScene : MonoBehaviour
{
    [SerializeField] private Button tapStartButton; 
    const string sceneName = "MainGame";

    private void Awake()
    {
        ModalWindowSingletonManager.Instance.CloseModal();

        if(AssetsLoad.Instance.AssetLoaded == false)
        {
            StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal());
            StartCoroutine(AssetsLoad.Instance.LoadSounds(() =>
            {
                SoundManager.Instance.PlayBGM(SoundManager.BGMType.StartGameBGM);
            }));
        }
    }

    private void Start()
    {
        if(tapStartButton != null)
        {
            tapStartButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlayUISE(SoundManager.UISEType.Confirm);
                ChangeMainGameScene();
                });
        }
    }

    public void ChangeMainGameScene()
    {
        DungeonGameSceneManager.Instance.SceneChange(sceneName);
    }
}
