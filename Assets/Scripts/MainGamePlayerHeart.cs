using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamePlayerHeart : MonoBehaviour
{
    public Image heartIcon =>this.GetComponent<Image>();
    public Sprite HeartLessIcon;

    public void DamageChangeHeartIcon()
    {
        heartIcon.sprite = HeartLessIcon;
    }
}
