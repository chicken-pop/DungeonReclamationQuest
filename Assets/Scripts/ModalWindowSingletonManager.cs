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
    /// ���[�_���̉��n�\���̉�
    /// </summary>
    public void IsShowBackground(bool isVisible)
    {
        if(modalBackground != null)
        {
            modalBackground.SetActive(isVisible);
        }
    }

    /// <summary>
    /// ���[�f�B���O�C���[�W�̕\���̉�
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
    /// <param name="isShowBackground">���n�̔w�i��\�����邩</param>
    /// <param name="isShowLoadingImage">���[�f�B���O�p�̃C���[�W��\�����邩</param>
    /// <param name="calBackAction">�\�����I�������ɂȂ����������̂ł���Ύ��s����</param>
    /// <returns></returns>
    public IEnumerator ShowModal(bool isShow = true,
        bool isShowBackground = true,
        bool isShowLoadingImage = true,
        UnityAction callBackAction = null)
    {
        //Modal��\��
        isModalActive = isShow;
        IsShowBackground(isShowBackground);
        IsShowLoadingImage(isShowLoadingImage);
        yield return new WaitUntil(()=> isModalActive);

        yield return new WaitForSeconds(1);

        //modal���\���ɂ���
        IsShowBackground(false);
        IsShowLoadingImage(false);

        if(callBackAction!= null)
        {
            callBackAction.Invoke();
        }
    }

    //���[�_�������
    public void CloseModal()
    {
        IsShowBackground(false);
        IsShowLoadingImage(false);
        isModalActive = false;
    }
}
