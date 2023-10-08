using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ProductVisuals : MonoBehaviour, ISelectible
{
    public static Func<string, bool> ProductSelected;
    private string Name;

    [SerializeField] private Image productSpr;

    public void Select()
    {
        if (ProductSelected?.Invoke(Name) == true)
        {
            PlaySound.Instance.Play("product_select");
            GetComponent<Animator>().SetTrigger("Select");
        }
    }

    public void SetProductData(string name, Sprite spr)
    {
        Name = name;
        productSpr.sprite = spr;
    }
}
