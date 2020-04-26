using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameObject PopupManager;
    public GameObject PausePopup;
    public GameObject GameOverPopup;
    public GameObject HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        PopupManager.SetActive(false);
        PausePopup.SetActive(false);
        GameOverPopup.SetActive(false);
        HighScoreText.SetActive(false);
}

public void PauseGame()
    {
        AudioManager.instance.PlaySound("button_press");
        PopupManager.SetActive(true);
        PausePopup.SetActive(true);
        GameOverPopup.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        AudioManager.instance.PlaySound("button_press");
        Time.timeScale = 1.0f;
        PopupManager.SetActive(false);
        PausePopup.SetActive(false);
        GameOverPopup.SetActive(false);
    }

    public void GoToMainMenu()
    {
        AudioManager.instance.PlaySound("button_press");
        PausePopup.SetActive(false);
        PopupManager.SetActive(false);
        GameOverPopup.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartGame()
    {
        AudioManager.instance.PlaySound("button_press");
        Time.timeScale = 1.0f;
        PausePopup.SetActive(false);
        PopupManager.SetActive(false);
        GameOverPopup.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void GameOver()
    {
        PopupManager.SetActive(true);
        GameOverPopup.SetActive(true);
        PausePopup.SetActive(false);
    }

    public void ShowNewHighScore(bool new_highscore)
    {
        HighScoreText.SetActive(true);
        int score = PlayerPrefs.GetInt("HighScore");
        string score_text = new_highscore ? "New Highscore : " : "Highscore : ";
        HighScoreText.gameObject.GetComponent<TextMeshProUGUI>().text = score_text + score.ToString();
    }
}
