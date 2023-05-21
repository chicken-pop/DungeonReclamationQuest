using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalBase : MonoBehaviour
{
    /// <summary>
    /// 1つ目のボタン
    /// </summary>
    [SerializeField]
    private Button primaryButton;

    /// <summary>
    /// 2つ目のボタン
    /// </summary>
    [SerializeField]
    private Button secondaryButton;

    public virtual void ShowButtonModal()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void CloseButtonModal()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void ButtonModalInitialize(UnityAction primaryAction, UnityAction secondaryAction = null)
    {
        primaryButton.gameObject.SetActive(false);
        secondaryButton.gameObject.SetActive(false);

        if(primaryButton != null)
        {
            primaryButton.gameObject.SetActive(true);
            primaryButton.onClick.AddListener(() => primaryAction.Invoke());
        }
        if(secondaryButton != null && secondaryAction != null)
        {
            secondaryButton.gameObject.SetActive(true);
            secondaryButton.onClick.AddListener(()=>secondaryAction.Invoke());
        }
    }


}
