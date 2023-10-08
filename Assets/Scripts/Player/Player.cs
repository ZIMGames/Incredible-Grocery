using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IPlayer
{
    public static Action SellProducts;

    private bool canSell;

    private void Start()
    {
        canSell = false;
        GameManager.ReadyToSell += ToogleSell;
    }
    public void Sell()
    {
        PlaySound.Instance.Play("button");
        if (canSell)
        {
            canSell = false;
            SellProducts?.Invoke();
        }
    }

    public void showProducts(List<Sprite> productSprites, GameObject OnionPrefab)
    {
        GameObject _onionPrefab = Instantiate(OnionPrefab, gameObject.transform);
        _onionPrefab.GetComponent<OnionController>().SpawnProducts(productSprites);
    }

    public void showProducts(List<Sprite> productSprites, GameObject OnionPrefab, List<bool> correctProducts)
    {
        GameObject _onionPrefab = Instantiate(OnionPrefab, gameObject.transform);
        _onionPrefab.GetComponent<OnionController>().SpawnProducts(productSprites, correctProducts);
    }

    private void ToogleSell(bool value)
    {
        canSell = value;
    }

    private void OnDestroy()
    {
        GameManager.ReadyToSell -= ToogleSell;
    }
}
