using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndGameButton : MonoBehaviour
{
    public Canvas endGameCanvas;
    public PlayerSounds PLAYER_SOUNDS;
    public Canvas uiCanvas;
    public Canvas transitionCanvas;
    public VideoPlayer backgroundVideo;

    public void endGame()
    {
        //endGameCanvas.gameObject.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //Debug.Log("Contact made");

        StartCoroutine(PlayEnding());
    }

        
    public void Start()
    {
        endGameCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    IEnumerator PlayEnding()
    {
        PLAYER_SOUNDS.KillPlayerSounds();

        uiCanvas.gameObject.SetActive(false);

        transitionCanvas.gameObject.SetActive(true);
        VideoPlayer transitionPlayer = transitionCanvas.GetComponentInChildren<VideoPlayer>();

        if (transitionPlayer)
            transitionPlayer.Play();
        else
            Debug.Log("NO VIDEO PLAYER");

        yield return new WaitForSeconds(6);

        SceneManager.LoadScene("MainMenu");
    }
}
