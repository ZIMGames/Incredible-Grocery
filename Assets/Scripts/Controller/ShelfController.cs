using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
