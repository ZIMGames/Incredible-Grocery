using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerVisual : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayAnimation(float waitTime)
    {
        Invoke("Play", waitTime);
    }

    private void Play()
    {
        animator.SetTrigger("Play");
    }
}
