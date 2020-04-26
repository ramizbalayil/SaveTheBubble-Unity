using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool timer_running = true;
    public Animator animator;

    public void StartTimer()
    {
        gameObject.SetActive(true);
        animator.SetBool("IsActive", true);
        timer_running = true;
    }

    public void ResumeGame()
    {
        timer_running = false;
        gameObject.SetActive(false);
    }

    public void PopSound()
    {
        AudioManager.instance.PlaySound("timer_beep");
    }

    public void GoSound()
    {
        AudioManager.instance.PlaySound("go_beep");
    }
}
