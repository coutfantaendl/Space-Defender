using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndex);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

