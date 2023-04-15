using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassiveIncome : MonoBehaviour
{
    [SerializeField] int _income;
    [SerializeField] MoneyResources _resources;
    [SerializeField] private TextMeshProUGUI _text;
    private Coroutine _currentCoroutine;


    private void Start()
    {
        _currentCoroutine = StartCoroutine(IncomeCouruntine(_income));
    }

    private IEnumerator IncomeCouruntine(int income)
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            _resources.AddIncome(income);
            _text.text = $"{income}/sec";

        }
    }

    public void AddOneIncome()
    {
        SetIncome(_income + 1);
    }


    public void SetIncome(int income)
    {
        _income = income;
        stopCurrentCoroutine();
        _text.text = $"{income}/sec";
        _currentCoroutine = StartCoroutine(IncomeCouruntine(_income));
    }

    private void stopCurrentCoroutine()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }
}