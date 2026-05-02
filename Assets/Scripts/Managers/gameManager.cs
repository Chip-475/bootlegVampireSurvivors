using UnityEngine;
using UnityEngine.InputSystem;

public class gameManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        data.isPaused = true;
        togglePause();
    }

    public void togglePause()
    {
        if (data.isPaused)
        {
            data.isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            data.isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
