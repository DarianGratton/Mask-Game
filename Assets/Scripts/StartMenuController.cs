using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuController : MonoBehaviour
{
    public Canvas startGame;
    //Start button loads the scene
    public void OnStartClick()
    {
        SceneManager.LoadScene("MylesScene");
    }

    //...or not button quits the application
    public void OnExitClick()
    {
        Application.Quit();
    }
}
