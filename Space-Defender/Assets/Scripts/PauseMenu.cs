using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isSoundEnable = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();

            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartLevel()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        ScoreManager.Instance.UpdateScoreTextReference();
    }

    private void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1;
        RestartLevel();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ToggleSound()
    {
        isSoundEnable = !isSoundEnable;

        AudioListener.pause = !isSoundEnable;
    }
}
