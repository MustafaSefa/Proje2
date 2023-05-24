using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject panel;
    public Player_Controller p;
    public void pauseGame()
    {
        if (isPaused == false)
        {
            panel.SetActive(true);
            Sound_Controller.audioSource.mute = true;
            p.c.Stop();
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void ResumeGame()
    {
        if (isPaused == true)
        {
            panel.SetActive(false);
            Sound_Controller.audioSource.mute = false;
            p.c.Play();
            Time.timeScale = 1;
            isPaused = false;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
