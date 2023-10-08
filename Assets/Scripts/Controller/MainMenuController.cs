using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameManager _gameManager;


    public void StartGame()
    {
        PlaySound.Instance.Play("button");
        GetComponent<Animator>().SetTrigger("Start");
    }

    public void StartRound()
    {
        _gameManager.NewRound();
        gameObject.SetActive(false);
    }


    public void Exit()
    {
        PlaySound.Instance.Play("button");
        Application.Quit();
    }
}
