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
        StartCoroutine(SpawnDragonCoroutine(egg.transform.position, eggLifeTime));
        Destroy(egg, eggLifeTime);
    }

    private IEnumerator SpawnDragonCoroutine(Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject dragon = Instantiate(dragonPrefab, position, Quaternion.identity);
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
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            pooRigidbody.AddForce(randomDirection * Random.Range(1f, 3f), ForceMode2D.Impulse);
            Destroy(poo, pooLifeTime);
        }
    }
}
