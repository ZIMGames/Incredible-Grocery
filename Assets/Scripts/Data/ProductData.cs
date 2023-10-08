using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Product")]
public class ProductData : ScriptableObject
{
    public string Name;
    public Sprite ProductSprite;
}
