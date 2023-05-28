using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ModalWindowSingletonManager : SingletonMonoBehaviour<ModalWindowSingletonManager>
{
    [SerializeField]
    private GameObject modalBackground;

    [SerializeField]
    private GameObject loadingImage;

    public bool isModalActive = false;

    private void Start()
    {
        modalBackground.SetActive(false);
        loadingImage.SetActive(false);
    }

    /// <summary>
    /// モーダルの下地表示の可否
    /// </summary>
    public void IsShowBackground(bool isVisible)
    {
        if(modalBackground != null)
        {
            modalBackground.SetActive(isVisible);
        }
    }

    /// <summary>
    /// ローディングイメージの表示の可否
    /// </summary>
    /// <param name="isVisible"></param>
    public void IsShowLoadingImage(bool isVisible)
    {
        if(loadingImage != null)
        {
            loadingImage.SetActive(isVisible);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isShowBackground">下地の背景を表示するか</param>
    /// <param name="isShowLoadingImage">ローディング用のイメージを表示するか</param>
    /// <param name="calBackAction">表示が終わった後にないかしたいのであれば実行する</param>
    /// <returns></returns>
    public IEnumerator ShowModal(bool isShow = true,
        bool isShowBackground = true,
        bool isShowLoadingImage = true,
        UnityAction callBackAction = null)
    {
        //Modalを表示
        isModalActive = isShow;
        IsShowBackground(isShowBackground);
        IsShowLoadingImage(isShowLoadingImage);
        yield return new WaitUntil(()=> isModalActive);

        yield return new WaitForSeconds(1);

        //modalを非表示にする
        IsShowBackground(false);
        IsShowLoadingImage(false);

        if(callBackAction!= null)
        {
            callBackAction.Invoke();
        }
    }

    //モーダルを閉じる
    public void CloseModal()
    {
        IsShowBackground(false);
        IsShowLoadingImage(false);
        isModalActive = false;
    }
}
