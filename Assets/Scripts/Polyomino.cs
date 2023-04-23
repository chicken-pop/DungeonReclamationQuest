using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polyomino : MonoBehaviour
{
    private Vector3 offset;

    //�}�E�X���N���b�N���ꂽ���Ɏ��s����鏈��
    private void OnMouseDown()
    {
        offset =  transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //�}�E�X���h���b�N����Ă���ԂɎ��s����鏈��
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x , newPosition.y, transform.position.x);
    }
}
