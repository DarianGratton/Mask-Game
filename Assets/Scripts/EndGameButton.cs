using UnityEngine;
using System.Collections;

public class EndGameButton : MonoBehaviour
{
    public Canvas endGame;

    private void OnTriggerEnter(Collider playerCharacter)
    {
        endGame.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Contact made");
        
    }
    public void Start()
    {
        endGame.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
