using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Settings;
    public GameObject Social;

    public GameObject MusicButton;
    public GameObject AudioButton;

    public Sprite MusicEnabled;
    public Sprite MusicDisabled;
    public Sprite AudioEnabled;
    public Sprite AudioDisabled;

    Image music_image_comp;
    Image audio_image_comp;
    public void Start()
    {
        music_image_comp = MusicButton.GetComponent<Image>();
        audio_image_comp = AudioButton.GetComponent<Image>();
        ShowMainMenu();
        PlayMusic();
    }

    public void ShowMainMenu()
    {
        Menu.SetActive(true);
        Settings.SetActive(false);
        Social.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.activeSelf == true)
        {
            AudioManager.instance.PlaySound("button_press");
            ShowMainMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Social.activeSelf == true)
        {
            ShowSettings();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

    }

    public void PlayMusic()
    {
        int audio_enabled = PlayerPrefs.GetInt("Audio", 1);
        int music_enabled = PlayerPrefs.GetInt("Music", 1);
        if (audio_enabled == 1)
        {
            audio_image_comp.sprite = AudioEnabled;
        }
        else
        {
            audio_image_comp.sprite = AudioDisabled;
        }
        if (music_enabled == 1)
        {
            music_image_comp.sprite = MusicEnabled;
        }
        else
        {
            music_image_comp.sprite = MusicDisabled;
        }
    }

    public void ShowSettings()
    {
        AudioManager.instance.PlaySound("button_press");
        Settings.SetActive(true);
        Menu.SetActive(false);
        Social.SetActive(false);
    }

    public void ShowSocial()
    {
        AudioManager.instance.PlaySound("button_press");
        Social.SetActive(true);
        Settings.SetActive(false);
        Menu.SetActive(false);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySound("button_press");
        Application.Quit();
    }

    public void PlayGame()
    {
        AudioManager.instance.PlaySound("button_press");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleMusic()
    {
        AudioManager.instance.PlaySound("button_press");
        int music_enabled = PlayerPrefs.GetInt("Music", 1);
        if (music_enabled == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            music_image_comp.sprite = MusicDisabled;
            AudioManager.instance.StopMusic();
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            music_image_comp.sprite = MusicEnabled;
            AudioManager.instance.PlayMusic();
        }
    }

    public void ToggleAudio()
    {
        AudioManager.instance.PlaySound("button_press");
        int audio_enabled = PlayerPrefs.GetInt("Audio", 1);
        if (audio_enabled == 1)
        {
            PlayerPrefs.SetInt("Audio", 0);
            audio_image_comp.sprite = AudioDisabled;
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 1);
            audio_image_comp.sprite = AudioEnabled;
        }
    }

    public void OpenFacebook()
    {
        AudioManager.instance.PlaySound("button_press");
        Application.OpenURL("https://www.facebook.com/angelcrewstudios");
    }

    public void OpenInstagram()
    {
        AudioManager.instance.PlaySound("button_press");
        Application.OpenURL("https://www.instagram.com/angelcrewstudios/");
    }

    public void OpenTwitter()
    {
        AudioManager.instance.PlaySound("button_press");
        Application.OpenURL("https://twitter.com/angelcrewstudio");
    }
}
