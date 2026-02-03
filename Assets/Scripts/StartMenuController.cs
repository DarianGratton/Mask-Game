using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;

public class StartMenuController : MonoBehaviour
{
    public Canvas transitionCanvas;
    public VideoPlayer backgroundVideo;
    public Canvas backgroundCanvas;
    public Canvas uiCanvas;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Start button loads the scene
    public void OnStartClick()
    {
        StartCoroutine(PlayTransition());
    }

    //...or not button quits the application
    public void OnExitClick()
    {
        Application.Quit();
    }

    IEnumerator PlayTransition()
    {
        backgroundVideo.Stop();
        
        backgroundCanvas.gameObject.SetActive(false);
        uiCanvas.gameObject.SetActive(false);

        transitionCanvas.gameObject.SetActive(true);
        VideoPlayer transitionPlayer = transitionCanvas.GetComponentInChildren<VideoPlayer>();

        if (transitionPlayer)
            transitionPlayer.Play();
        else
            Debug.Log("NO VIDEO PLAYER");

        yield return new WaitForSeconds(6);

        SceneManager.LoadScene("MainScene_Amir");
    }
}
