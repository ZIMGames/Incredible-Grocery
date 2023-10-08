using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnionController : MonoBehaviour
{
    public static Action OnionHide;
    public static Action EndRound;

    [SerializeField] private GameObject productPrefab;
    [SerializeField] private GameObject answerPrefab;

    [SerializeField] private Sprite[] answersSprites;

    private Animator animator;
    public float delayStep = 0.5f;
    public float startDelay = 1.3f;
    public float emojiDuration = 1f;
    private bool ProductsShown;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SpawnProducts(List<Sprite> productSprites)
    {
        OnionOnSound();
        ProductsShown = true;

        int numberOfProducts = productSprites.Count;

        float interval = 0.75f / (numberOfProducts);

        for (int i = 0; i < numberOfProducts; i++)
        {
            GameObject _productPrefab = Instantiate(productPrefab, gameObject.transform) as GameObject;
            _productPrefab.GetComponent<SpriteRenderer>().sprite = productSprites[i];

            float xPosition;

            if (numberOfProducts == 1)
            {
                xPosition = 0;
            }
            else
            {
                xPosition = -0.25f + ((numberOfProducts + 1) % 2) * 0.1f + interval * i;
            }

            _productPrefab.transform.localPosition = new Vector2(xPosition, _productPrefab.transform.localPosition.y);
        }

        Invoke("hideProducts", GameSettings.Instance.TimeToMemoryProducts);
    }

    public void SpawnProducts(List<Sprite> productSprites, List<bool> correctProducts)
    {
        OnionOnSound();

        ProductsShown = false;

        int numberOfProducts = productSprites.Count;

        float interval = 0.75f / (numberOfProducts);

        for (int i = 0; i < numberOfProducts; i++)
        {
            float delayAnim = startDelay + i * delayStep;
            GameObject _productPrefab = Instantiate(productPrefab, gameObject.transform) as GameObject;
            _productPrefab.GetComponent<SpriteRenderer>().sprite = productSprites[i];
            _productPrefab.GetComponent<SoloProductVisual>().PlayDispAnim(delayAnim);

            GameObject _answerPrefab = Instantiate(answerPrefab, gameObject.transform) as GameObject;
            _answerPrefab.GetComponent<AnswerVisual>().PlayAnimation(delayAnim);

            if (correctProducts[i])
            {
                _answerPrefab.GetComponent<SpriteRenderer>().sprite = answersSprites[0];
            }
            else
            {
                _answerPrefab.GetComponent<SpriteRenderer>().sprite = answersSprites[1];
            }

            float xPosition;

            if (numberOfProducts == 1)
            {
                xPosition = 0;
            }
            else
            {
                xPosition = -0.25f + ((numberOfProducts + 1) % 2) * 0.1f + interval * i;
            }

            _productPrefab.transform.localPosition = new Vector2(xPosition, _productPrefab.transform.localPosition.y);
            _answerPrefab.transform.localPosition = new Vector2(xPosition, _productPrefab.transform.localPosition.y);
        }

        Invoke("hideProducts", numberOfProducts * delayStep + startDelay + 1);
        Invoke("callToEndRound", numberOfProducts * delayStep + startDelay + 1);
    }

    public void ShowEmoji(Sprite emojiSprite)
    {
        OnionOnSound();

        ProductsShown = false;

        GameObject _productPrefab = Instantiate(productPrefab, gameObject.transform) as GameObject;
        _productPrefab.GetComponent<SpriteRenderer>().sprite = emojiSprite;

        float xPosition = 0;
        _productPrefab.transform.localPosition = new Vector2(xPosition, _productPrefab.transform.localPosition.y);

        Invoke("hideProducts", emojiDuration);
    }

    private void OnionOnSound()
    {
        PlaySound.Instance.Play("OnionOn");
    }
    private void callToEndRound()
    {
        EndRound?.Invoke();
    }

    private void hideProducts()
    {
        PlaySound.Instance.Play("OnionOff");

        animator.SetTrigger("Hide");
    }

    private void Destroy()
    {
        if (ProductsShown)
        {
            OnionHide?.Invoke();
        }

        Destroy(gameObject);
    }
}
