using UnityEngine.SceneManagement;
using UnityEngine;


public class EndScreen : MonoBehaviour
{
    //restart the program
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Quit the program
    public void Quit()
    {
        Application.Quit();
    }
}
