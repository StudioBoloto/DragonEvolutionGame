using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class MoneyResources : MonoBehaviour
{
    public int Coins { get; private set; }
    [SerializeField] private UICounter _counter;
    

    public event Action<int> OnChangeCoins;
    public event Action<Vector3> OnCollectCoins;

    private void Start()
    {
        OnChangeCoins?.Invoke(Coins);
    }

    public void AddIncome(int value)
    {
        Coins += value;
        OnChangeCoins?.Invoke(Coins);
        _counter.DisplayWithoutAnimation();
    }

    public void CollectCoins(int value)
    {
        StartCoroutine(AddCoinsAfterDelay(value, 0.0f));
    }

    private IEnumerator AddCoinsAfterDelay(int value, float delay)
    {
        yield return new WaitForSeconds(delay);
        Coins += value;
        OnChangeCoins?.Invoke(Coins);
        _counter.Display();
    }

    public bool TryBuy(int price)
    {
        if (Coins >= price)
        {
            Coins -= price;
            _counter.Display();
            OnChangeCoins.Invoke(Coins);
            return true;
        }
        else
        {
            return false;
        }
    }
}
