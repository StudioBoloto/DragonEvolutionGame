using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector2 _mousePosition;
    private float _offsetX, _offsetY;
    public static bool mouseReleased;

    private void OnMouseDown()
    {
        mouseReleased = false;
        _offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        _offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(_mousePosition.x - _offsetX, _mousePosition.y - _offsetY);
    }

    private void OnMouseUp()
    {
        mouseReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjName;
        string collisionGameobjName;

        thisGameobjName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjName = collision.gameObject.name.Substring(0, name.IndexOf("_"));


        if (mouseReleased && thisGameobjName == "Circle" && thisGameobjName == collisionGameobjName)
        {
            Instantiate(Resources.Load("Sqare_Object"), transform.position, Quaternion.identity);
            mouseReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (mouseReleased && thisGameobjName == "Sqare" && thisGameobjName == collisionGameobjName)
        {
            Instantiate(Resources.Load("Triangle_Object"), transform.position, Quaternion.identity);
            mouseReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
