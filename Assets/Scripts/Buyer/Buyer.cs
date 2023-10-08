using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Buyer : MonoBehaviour, IBuyer
{
    public static Action BuyerAtCassa;
    public static Action RoundEnded;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void showProducts(List<Sprite> productSprites, GameObject OnionPrefab)
    {
        GameObject _onionPrefab = Instantiate(OnionPrefab, gameObject.transform);
        _onionPrefab.GetComponent<OnionController>().SpawnProducts(productSprites);
    }

    public void showEmoji(Sprite emojiSprite, GameObject OnionPrefab)
    {
        GameObject _onionPrefab = Instantiate(OnionPrefab, gameObject.transform);
        _onionPrefab.GetComponent<OnionController>().ShowEmoji(emojiSprite);
    }

    public void GoToCassa()
    {
        animator.SetTrigger("Go");
    }

    public void AtCassa()
    {
        BuyerAtCassa?.Invoke();
    }
    
    public void LeaveCassa()
    {
        animator.SetTrigger("Leave");
    }

    public void BuyerExitSuccess()
    {
        RoundEnded?.Invoke();
    }

    public void NewRound()
    {
        animator.SetTrigger("Restart");
    }
}
