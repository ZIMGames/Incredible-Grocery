using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CashController : MonoBehaviour
{
    private int CashAmount;
    private string startCashText = "$ ";
    [SerializeField] private Text CashText;
    [SerializeField] private GameObject CashAnimObj;

    private void Start()
    {
        GameManager.RoundAmount += AddCash;

        CashAmount = PlayerSettings.GetMoneyData();
        CashText.text = startCashText + CashAmount.ToString();
    }

    private void AddCash(int amount)
    {
        PlaySound.Instance.Play("money");

        CashAmount += amount;
        PlayerPrefs.SetInt("Money", CashAmount);
        CashText.text = startCashText + CashAmount.ToString();

        GameObject _animObj = Instantiate(CashAnimObj, gameObject.transform) as GameObject;
        _animObj.GetComponent<CashObj>().SetCashValue(amount);
    }

    private void OnDestroy()
    {
        GameManager.RoundAmount -= AddCash;
    }
}
