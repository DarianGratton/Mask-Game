using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public float MAX_OXYGEN = 100f;
    public float OXYGEN_LOSS_PER_SECOND = 5f;
    public float DEATH_MESSAGE_DURATION = 2f;
    public bool IS_LOSING_OXYGEN_ON_START = true;

    public Canvas DEATH_MESSAGE_CANVAS;
    public GameManager GAME_MANAGER;
    public PlayerSounds PLAYER_SOUNDS;

    [SerializeField]
    private float currentOxygen;
    private bool isLosingOxygen;
    [SerializeField]
    private float deathMessageTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathMessageTimer = 0;
        DEATH_MESSAGE_CANVAS.gameObject.SetActive(false);
        currentOxygen = MAX_OXYGEN;
        isLosingOxygen = IS_LOSING_OXYGEN_ON_START;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLosingOxygen)
            currentOxygen -= Time.deltaTime * OXYGEN_LOSS_PER_SECOND;

        if (currentOxygen <= 0)
        {
            KillPlayer();
        }

        if (deathMessageTimer > 0)
        {
            deathMessageTimer -= Time.deltaTime;
            if (deathMessageTimer <= 0)
                DEATH_MESSAGE_CANVAS.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        
    }
    
    private void KillPlayer()
    {
        DEATH_MESSAGE_CANVAS.gameObject.SetActive(true);
        deathMessageTimer = DEATH_MESSAGE_DURATION;
        currentOxygen = MAX_OXYGEN;

        PLAYER_SOUNDS.ResetPlayerSounds();

        // Pause game
        GAME_MANAGER.PauseGame();
    }
    
    public void StopLosingOxygen()
    {
        isLosingOxygen = false;
    }
    
    public void StartLosingOxygen()
    {
        isLosingOxygen = true;
    }
    
    public void RestoreOxygen(float restoreAmount)
    {
        currentOxygen += restoreAmount;
        
        if (currentOxygen > MAX_OXYGEN)
            currentOxygen = MAX_OXYGEN;
            
    }

    public float GetOxygenPercent()
    {
        return currentOxygen / MAX_OXYGEN;
    }
}
