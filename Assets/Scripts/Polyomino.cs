using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polyomino : MonoBehaviour
{
    private Vector3 offset;

    //マウスがクリックされた時に実行される処理
    private void OnMouseDown()
    {
        offset =  transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //マウスがドラックされている間に実行される処理
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x , newPosition.y, transform.position.x);
    }
}
