using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public float TimeToMemoryProducts = 5.0f;
    public int MinProducts = 1;
    public int MaxProducts = 3;
    public int RewardPerProduct = 10;
    public bool NeedShuffleProducts = true;

    private void Awake()
    {
        Instance = this;
    }
}
