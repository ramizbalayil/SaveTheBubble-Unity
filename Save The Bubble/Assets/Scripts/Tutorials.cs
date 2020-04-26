using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    TextMeshProUGUI tut_text;
    public GameObject timer;

    public string[] text_strings;
    int index = 0;


    void Start()
    {
        tut_text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        tut_text.SetText(text_strings[index]);
    }

    public void NextTutorial()
    {
        AudioManager.instance.PlaySound("button_press");
        index += 1;
        if (index < text_strings.Length)
        {
            tut_text.SetText(text_strings[index]);
        }
        else
        {
            timer.GetComponent<Timer>().StartTimer();
            Destroy(gameObject);
        }
    }

}
