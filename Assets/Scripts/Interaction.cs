using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoneyResources _resources;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = new RaycastHit2D();
            hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.TryGetComponent(out Collectable collectable))
            {
                collectable.Collect(_resources);
            }

        }

    }
}
