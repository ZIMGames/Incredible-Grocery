using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloProductVisual : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayDispAnim(float delay)
    {
        Invoke("PlayAnim", delay);
    }

    private void PlayAnim()
    {
        animator.SetTrigger("Dispertion");
    }
}
