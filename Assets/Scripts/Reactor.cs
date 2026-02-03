using UnityEngine;
using UnityEngine.Audio;

public class Reactor : MonoBehaviour
{
    public AudioSource source;
    public AudioClip humSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source.loop = true;
		source.clip = humSound;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
