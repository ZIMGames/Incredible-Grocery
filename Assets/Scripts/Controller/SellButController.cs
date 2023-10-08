using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SellButController : MonoBehaviour
{
    private Image ButImg;
    [SerializeField] private Color Deactive, Active;

    private void Start()
    {
        ButImg = GetComponent<Image>();
        GameManager.ReadyToSell += ChangeButOpacity;
    }

    private void ChangeButOpacity(bool canSell)
    {
        if (canSell)
        {
            ButImg.color = Active;
        } else
        {
            ButImg.color = Deactive;
        }
    }

    private void OnDestroy()
    {
        GameManager.ReadyToSell -= ChangeButOpacity;
    }
}
