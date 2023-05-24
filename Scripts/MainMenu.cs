using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource a;
    public static bool p = false;
    private void Start()
    {
        a.Play();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        p = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Store()
    {
        p = true;
        SceneManager.LoadScene("Store");
    }
}
