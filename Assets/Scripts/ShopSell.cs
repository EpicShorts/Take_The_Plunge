using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSell : MonoBehaviour
{
    public int Shop_Biscuit_Balence = 0;

    private string textOnScreen = "0";

    [SerializeField] private TextMeshProUGUI billboardTextMesh;
    [SerializeField] private ParticleSystem sellParticle;

    [SerializeField] private AudioSource audioSourceCash;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textOnScreen = Shop_Biscuit_Balence.ToString();
        billboardTextMesh.text = textOnScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBalence(int value)
    {
        Shop_Biscuit_Balence += value;
        Debug.Log("[ShopSell] "+ value + " has been added, new total: "+Shop_Biscuit_Balence);
        textOnScreen = Shop_Biscuit_Balence.ToString();
        billboardTextMesh.text = textOnScreen;
        sellParticle.Play();
        audioSourceCash.Play();
    }
    public bool RemoveFromBalence(int cost)
    {
        if (Shop_Biscuit_Balence - cost >= 0)
        {
            Shop_Biscuit_Balence -= cost;
            textOnScreen = Shop_Biscuit_Balence.ToString();
            billboardTextMesh.text = textOnScreen;
            return true;
        }
        else
        {
            Debug.Log("[ShopSell] Not enough to Buy, Balence: " + Shop_Biscuit_Balence + " Item cost: " + cost);
            return false;
        }
    }
}
