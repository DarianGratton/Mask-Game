using UnityEngine;

public class EndGameInventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[3];
    public void useKeyCard()
    {
        for(int i = 0; i <= 2; i++)
        {
            if (inventory[i] != null && inventory[i].CompareTag("KeyCard"))
            {
                inventory[i] = null;
                Debug.Log("The key has been used");
                break;
            }
        }

    }

    public void addKeyCard(GameObject item)
    {
        for(int i = 0; i <= 2; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " has been added to the reactor!");

                if(i == 2)
                {
                    this.gameObject.GetComponent<EndGameButton>().endGame();
                }

                break;
            }
        }
    }
    public bool hasKeyCard()
    {
        foreach (GameObject item in inventory)
        {
            if(item != null && item.CompareTag("KeyCard"))
            {
                return true;
            }
        }
        return false;
    }

}