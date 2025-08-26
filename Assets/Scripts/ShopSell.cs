using UnityEngine;

public class ShopSell : MonoBehaviour
{
    public int Shop_Biscuit_Balence = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBalence(int value)
    {
        Shop_Biscuit_Balence += value;
        Debug.Log("[ShopSell] "+ value + " has been added, new total: "+Shop_Biscuit_Balence);
    }
    public bool RemoveFromBalence(int cost)
    {
        if (Shop_Biscuit_Balence - cost >= 0)
        {
            Shop_Biscuit_Balence -= cost;
            return true;
        }
        else
        {
            Debug.Log("[ShopSell] Not enough to Buy, Balence: " + Shop_Biscuit_Balence + " Item cost: " + cost);
            return false;
        }
    }
}
