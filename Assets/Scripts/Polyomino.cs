using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polyomino : MonoBehaviour
{
    //オブジェクトの原点
    private Vector3 offset;

    public bool IsDungeonPolyomino = false;

    public bool IsDragging = false;

    public bool IsBuried = false;
    public enum PolyominoTypes
    {
        Invalid,
        A,
        C,
        L,
        O,
        T,
        W,
        Cross
    }
    public PolyominoTypes PolyominoType = PolyominoTypes.Invalid;

    private BoxCollider2D polyominoCollider => GetComponent<BoxCollider2D>();

    public BoxCollider2D GetPolyominoCollider
    {
        get { return polyominoCollider; }
    }

    private Rigidbody2D polyominoRigidbody2D => GetComponent<Rigidbody2D>();

    public Rigidbody2D GetPpolyominoRigidbody2D
    {
        get { return polyominoRigidbody2D; }
    }

    private void Start()
    {
        if (!IsDungeonPolyomino)
        {
            foreach (var mino in this.transform.GetComponentsInChildren<SpriteRenderer>())
            {
                mino.sortingOrder=5;
            }
        }
    }

    //マウスがクリックされた時に実行される処理
    private void OnMouseDown()
    {
        if (IsDungeonPolyomino)
        {
            return;
        }
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //マウスがドラックされている間に実行される処理
    private void OnMouseDrag()
    {
        if (IsDungeonPolyomino)
        {
            return;
        }
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.x);
        IsDragging = true;
    }

    private void OnMouseUp()
    {
        IsDragging = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Polyomino>())
        {
            var poly = collision.GetComponent<Polyomino>();

            if(!poly.IsDragging && !poly.IsDungeonPolyomino)
            {
                //var isFullyInside = this.polyominoCollider.bounds.Contains(poly.polyominoCollider.bounds.min) &&
                //    this.polyominoCollider.bounds.Contains(poly.polyominoCollider.bounds.max);
                // Debug.Log(isFullyInside);
                //埋まっているかを確認
                if(/*isFullyInside &&*/ poly.PolyominoType == this.PolyominoType)
                {
                    poly.transform.position = this.transform.position;
                    IsBuried = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Polyomino>())
        {
            var poly= collision.GetComponent<Polyomino>();
            if (!poly.IsDungeonPolyomino)
            {
                IsBuried = false;
            }
        }
    }
}
