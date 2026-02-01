using UnityEngine;
using System.Collections;

public class EndGameButton : MonoBehaviour
{
    public Canvas endGameCanvas;



    public void endGame()
    {
        endGameCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Contact made");
    }

        
    public void Start()
    {
        endGameCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
