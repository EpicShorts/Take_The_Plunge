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

    public void AddToBalence(int balence)
    {
        Shop_Biscuit_Balence += balence;
        Debug.Log("[ShopSell] "+balence+" has been added, new total: "+Shop_Biscuit_Balence);
    }
    public bool RemoveFromBalence(int balence)
    {
        if (Shop_Biscuit_Balence - balence > 0)
        {
            Shop_Biscuit_Balence -= balence;
            return true;
        }
        Debug.Log("[ShopSell] Not enough to Buy");
        return false;
    }
}
