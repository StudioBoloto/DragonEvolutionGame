using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject coinPrefab;
    public float moveSpeed = 5f;
    private GameObject groundObject;
    private float moveRangeX;
    private float moveRangeY;
    private Vector3 targetPosition;

    private void Start()
    {
        groundObject = GameObject.FindGameObjectWithTag("Ground");
        if (groundObject != null)
        {
            Bounds groundBounds = groundObject.GetComponent<Renderer>().bounds;
            moveRangeX = groundBounds.size.x / 2f;
            moveRangeY = groundBounds.size.y / 2f;
        }
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 centerPos = groundObject.transform.position;
        float randomX = Random.Range(centerPos.x - moveRangeX, centerPos.x + moveRangeX);
        float randomY = Random.Range(centerPos.y - moveRangeY, centerPos.y + moveRangeY);
        randomX = Mathf.Clamp(randomX, centerPos.x - moveRangeX, centerPos.x + moveRangeX);
        randomY = Mathf.Clamp(randomY, centerPos.y - moveRangeY, centerPos.y + moveRangeY);
        Vector3 randomPos = new Vector3(randomX, randomY, 0f);
        return randomPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EggSpawn"))
        {
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag("CoinSpawn"))
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}