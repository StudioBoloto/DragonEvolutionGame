using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Vector3 gravityDirection = -Camera.main.transform.forward;
        Vector2 gravity2D = new Vector2(gravityDirection.x, gravityDirection.y);
        Physics2D.gravity = gravity2D.normalized * 9.81f; 
    }
}
