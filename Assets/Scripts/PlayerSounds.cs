using UnityEngine;
using System.Collections.Generic;
using StarterAssets;
using System.Collections;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource stepsSource, heartbeatSource, breathingSource;
    public List<AudioClip> stepSounds, heartbeatSounds, breathingSounds;
    public FirstPersonController playerController;
    public Oxygen oxygen;
    public float panicOxygenPercent = 50f;

    private bool stepSoundPlaying, lowOxygen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lowOxygen = false;

        stepsSource.loop = false;
        heartbeatSource.loop = true;
        breathingSource.loop = true;

        breathingSource.clip = breathingSounds[0];
        breathingSource.Play();
        heartbeatSource.clip = heartbeatSounds[0];
        heartbeatSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player started moving recently, start playing walking sounds
        if (!stepSoundPlaying && playerController.GetTargetSpeed() > 0.1f)
        {
            StartCoroutine(PlayRandomFootstepLoop());
            stepSoundPlaying = true;
        } //If player stopped moving recently stop the walking sounds
        else if (stepSoundPlaying && playerController.GetTargetSpeed() < 0.1f)
        {
            stepSoundPlaying = false;
        }

        if (!lowOxygen && oxygen.GetOxygenPercent() <= panicOxygenPercent)
        {
            breathingSource.Stop();
            breathingSource.clip = breathingSounds[1];
            breathingSource.Play();
            heartbeatSource.Stop();
            heartbeatSource.clip = heartbeatSounds[1];
            heartbeatSource.Play();
            lowOxygen = true;
        }
    }

    IEnumerator PlayRandomFootstepLoop()
    {
        while (playerController.GetTargetSpeed() > 0.1f) // Infinite loop while walking
        {
            // Select a random clip and play it
            stepsSource.clip = stepSounds[Random.Range(0, stepSounds.Count)];
            stepsSource.Play();

            // Wait for the clip to finish, plus a random delay if specified
            yield return new WaitForSeconds(stepsSource.clip.length);
        }

        stepSoundPlaying = false;
    }
}
