using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject pooPrefab;
    [SerializeField] GameObject eggPrefab;
    [SerializeField] GameObject dragonPrefab;
    [SerializeField] float eggSpawnInterval = 30f;
    [SerializeField] float coinSpawnInterval = 5f;
    [SerializeField] float pooLifeTime = 5f;
    [SerializeField] float eggLifeTime = 10f;

    private float eggSpawnTimer;
    private float coinSpawnTimer;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        eggSpawnTimer += Time.deltaTime;
        coinSpawnTimer += Time.deltaTime;

        if (eggSpawnTimer >= eggSpawnInterval)
        {
            eggSpawnTimer = 0f;
            SpawnEgg();
        }

        if (coinSpawnTimer >= coinSpawnInterval)
        {
            coinSpawnTimer = 0f;
            SpawnPoo(transform.position, playerController.multiplier);

        }
    }

    private void SpawnEgg()
    {
        GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        egg.transform.localScale *= (1 + playerController.multiplier / 10);
        Invoke("SpawnDragon", eggLifeTime);
        Destroy(egg, eggLifeTime);
    }

    private void SpawnDragon()
    {
        GameObject dragon = Instantiate(dragonPrefab, transform.position, Quaternion.identity);
        PlayerController dragonController = dragon.GetComponent<PlayerController>();
        if (dragonController != null)
        {
            dragonController.multiplier = playerController.multiplier;
        }
    }


    public void SpawnPoo(Vector3 startPosition, float multiplier)
    {
        for (int i = 0; i < multiplier; i++)
        {
            GameObject poo = Instantiate(pooPrefab, startPosition, Quaternion.identity);

            Rigidbody2D pooRigidbody = poo.GetComponent<Rigidbody2D>();
            pooRigidbody.AddForce(Vector2.up * Random.Range(1f, 3f), ForceMode2D.Impulse);
            pooRigidbody.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode2D.Impulse);
            Destroy(poo, pooLifeTime);
        }
    }

}
