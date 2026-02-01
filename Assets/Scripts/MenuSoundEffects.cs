using UnityEngine;

public class MenuSoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonHoverSound, buttonPressSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonHoverSound()
    {
        audioSource.Stop();
        audioSource.clip = buttonHoverSound;
        audioSource.Play();
    }

    public void PlayButtonPressSound()
    {
        audioSource.Stop();
        audioSource.clip = buttonPressSound;
        audioSource.Play();
    }
}
