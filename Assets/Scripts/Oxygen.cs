using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public float MAX_OXYGEN = 100f;
    public float OXYGEN_LOSS_PER_SECOND = 1f;
    public bool IS_LOSING_OXYGEN_ON_START = true;
    
    private float currentOxygen;
    private bool isLosingOxygen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentOxygen = MAX_OXYGEN;
        isLosingOxygen = IS_LOSING_OXYGEN_ON_START;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLosingOxygen)
            currentOxygen -= Time.deltaTime;
        
        if (currentOxygen <= 0)
            KillPlayer();
    }

    private void FixedUpdate()
    {
        
    }
    
    private void KillPlayer()
    {
        
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
}
