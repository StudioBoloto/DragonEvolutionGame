using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject dragon1Prefab;
    [SerializeField] GameObject dragon2Prefab;
    [SerializeField] GameObject dragon3Prefab;
    [SerializeField] GameObject dragon4Prefab;

    [SerializeField] Button buttonBuy1;
    [SerializeField] Button buttonBuy2;
    [SerializeField] Button buttonBuy3;
    [SerializeField] Button buttonBuy4;

    void Start()
    {
        buttonBuy1.onClick.AddListener(SpawnDragon1);
        buttonBuy2.onClick.AddListener(SpawnDragon2);
        buttonBuy3.onClick.AddListener(SpawnDragon3);
        buttonBuy4.onClick.AddListener(SpawnDragon4);
    }

    void SpawnDragon1()
    {
        Instantiate(dragon1Prefab, Vector3.zero, Quaternion.identity);
    }

    void SpawnDragon2()
    {
        Instantiate(dragon2Prefab, Vector3.zero, Quaternion.identity);
    }

    void SpawnDragon3()
    {
        Instantiate(dragon3Prefab, Vector3.zero, Quaternion.identity);
    }

    void SpawnDragon4()
    {
        Instantiate(dragon4Prefab, Vector3.zero, Quaternion.identity);
    }
}

