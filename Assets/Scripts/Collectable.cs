using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    public void Collect(MoneyResources resources)
    {
        Destroy(gameObject);
        resources.CollectCoins(1, transform.position);
    }
}
