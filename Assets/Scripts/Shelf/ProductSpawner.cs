using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public GameObject prefab;
    public ProductDataList _productDataList;

    [SerializeField] private GameObject parentObj;

    private List<GameObject> productsTemp;

    private void Awake()
    {
        productsTemp = new List<GameObject>();
    }

    private void OnEnable()
    {
        SpawnFruits();
    }
    public void SpawnFruits()
    {
        if (GameSettings.Instance.NeedShuffleProducts)
        {
            _productDataList.List.Shuffle();
        }

        foreach (var item in _productDataList.List)
        {
            GameObject _obj = Instantiate(prefab, parentObj.transform) as GameObject;
            _obj.GetComponent<ProductVisuals>().SetProductData(item.name, item.ProductSprite);
            productsTemp.Add(_obj);
        }
    }

    private void ClearShelf()
    {
        for (int i = 0; i < productsTemp.Count; i++)
        {
            Destroy(productsTemp[i]);
        }
        productsTemp.Clear();
    }

    private void OnDisable()
    {
        ClearShelf();
    }
}

