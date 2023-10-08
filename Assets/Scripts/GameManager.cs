using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public int roundReward;

    public static Action<bool> ReadyToSell;
    public static Action<int> RoundAmount;

    [SerializeField] private Buyer _buyer;
    [SerializeField] private Player _player;

    [SerializeField] private Sprite badEmotion, goodEmotion;

    [SerializeField] private GameObject ShelfObj;
    [SerializeField] private GameObject OnionPrefab;

    public ProductDataList _productDataList;

    private List<string> correctProducts;
    private List<string> playerProducts;


    private void Start()
    {
        correctProducts = new List<string>();
        playerProducts = new List<string>();

        Buyer.BuyerAtCassa += chooseProducts;
        //Buyer.BuyerShoosedProducts += showAllProducts;
        ProductVisuals.ProductSelected += addProductToCart;
        Player.SellProducts += Sell;
        OnionController.OnionHide += showAllProducts;
        OnionController.EndRound += EndGame;
        Buyer.RoundEnded += NewRound;
    }

    public void NewRound()
    {
        correctProducts.Clear();
        playerProducts.Clear();

        _buyer.NewRound();
    }

    private void chooseProducts()
    {
        correctProducts.Clear();

        List<ProductData> products = _productDataList.List.Distinct().ToList();

        int productsCount = UnityEngine.Random.Range(GameSettings.Instance.MinProducts, GameSettings.Instance.MaxProducts + 1);

        if (productsCount > products.Count)
        {
            productsCount = products.Count;
        }

        List<Sprite> selectedProducts = new List<Sprite>();

        while (selectedProducts.Count < productsCount)
        {
            int randomIndex = UnityEngine.Random.Range(0, products.Count);

            selectedProducts.Add(products[randomIndex].ProductSprite);
            correctProducts.Add(products[randomIndex].name);
            products.RemoveAt(randomIndex);
        }

        _buyer.showProducts(selectedProducts, OnionPrefab);
    }

    private void showAllProducts()
    {
        ShelfObj.SetActive(true);
    }

    public void EndGame()
    {

        if (roundReward == correctProducts.Count * GameSettings.Instance.RewardPerProduct * 2)
        {
            _buyer.showEmoji(goodEmotion, OnionPrefab);
        } else
        {
            _buyer.showEmoji(badEmotion, OnionPrefab);
        }

        _buyer.LeaveCassa();

        RoundAmount?.Invoke(roundReward);
    }

    private void Sell()
    {
        ShelfObj.GetComponent<Animator>().SetTrigger("Off");

        List<ProductData> _productData = GetPlayerProducts();
        List<bool> missingProducts = CheckMissingProducts(_productData);

        roundReward = CalculateWinReward(missingProducts);

        _player.showProducts(ProductDataToSprite(_productData), OnionPrefab, missingProducts);
    }

    private List<Sprite> ProductDataToSprite(List<ProductData> data)
    {
        List<Sprite> dataSprites = new List<Sprite>();

        foreach (var item in data)
        {
            dataSprites.Add(item.ProductSprite);
        }

        return dataSprites;
    }

    private int CalculateWinReward(List<bool> missingProducts)
    {
        int money;
        int correctAnswers = 0;

        foreach (var item in missingProducts)
        {
            if (item)
            {
                correctAnswers++;
            }
        }

        money = GameSettings.Instance.RewardPerProduct * correctAnswers;

        if (correctAnswers == missingProducts.Count)
        {
            money *= 2;
        }

        return money;
    }

    private List<bool> CheckMissingProducts(List<ProductData> _productData)
    {
        List<bool> missingProducts = new List<bool>();

        for (int i = 0; i < _productData.Count; i++)
        {
            if (!correctProducts.Contains(_productData[i].Name))
            {
                missingProducts.Add(false);
            } else
            {
                missingProducts.Add(true);
            }
        }

        return missingProducts;
    }

    private List<ProductData> GetPlayerProducts()
    {
        List<ProductData> _productData = new List<ProductData>();

        foreach (var item in _productDataList.List)
        {
            if (playerProducts.Contains(item.Name))
            {
                _productData.Add(item);
            }
        }

        return _productData;
    }

    private bool addProductToCart(string name)
    {
        if (playerProducts.Contains(name))
        {
            playerProducts.Remove(name);
            ReadyToSell?.Invoke(false);
            return true;
        }
        else if (playerProducts.Count < correctProducts.Count)
        {
            playerProducts.Add(name);
            if (playerProducts.Count == correctProducts.Count)
            {
                ReadyToSell?.Invoke(true);
            }
            return true;

        } else
        {
            return false;
        }
    }

    private void OnDestroy()
    {
        Buyer.BuyerAtCassa -= chooseProducts;
        //Buyer.BuyerShoosedProducts -= showAllProducts;
        ProductVisuals.ProductSelected -= addProductToCart;
        Player.SellProducts -= Sell;
        OnionController.OnionHide -= showAllProducts;
        OnionController.EndRound -= EndGame;
        Buyer.RoundEnded -= NewRound;
    }
}
