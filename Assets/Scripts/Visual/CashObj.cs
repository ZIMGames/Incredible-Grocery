using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashObj : MonoBehaviour
{
    [SerializeField] private Text cashText;


    public void SetCashValue(int amount)
    {
        cashText.text = "+" + amount.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
