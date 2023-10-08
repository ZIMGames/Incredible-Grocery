using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/ProductList")]
public class ProductDataList : ScriptableObject
{
    public List<ProductData> List;
}
