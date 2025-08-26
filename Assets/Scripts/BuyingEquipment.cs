using UnityEngine;

public class BuyingEquipment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private ShopSell shopSell;
    [SerializeField] private OxygenSystem oxygenSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "BasicFins":
                if (shopSell.RemoveFromBalence(10)) IncreaseSwimSpeed(0.5f);
                break;
            case "BasicWeights":
                if (shopSell.RemoveFromBalence(5)) IncreaseDiveSpeed(0.5f);
                break;
            case "BasicOxygenTank":
                if (shopSell.RemoveFromBalence(20)) IncreaseMaxOxygenLevel(10);
                break;
            default:
                Debug.Log("Unknown ShopBuy tag");
                break;
        }
    }

    private void IncreaseSwimSpeed(float swimSpeed)
    {
        firstPersonController.underWaterSpeedMultiplyer += swimSpeed;
        Debug.Log("[BuyingEquipment] Swim Speed Increased");
    }

    private void IncreaseDiveSpeed(float diveSpeed)
    {
        firstPersonController.diveSpeedMultiplyer += diveSpeed;
        Debug.Log("[BuyingEquipment] Dive Speed Increased");
    }

    private void IncreaseMaxOxygenLevel(int level)
    {
        oxygenSystem.OxygenMax += level;
        Debug.Log("[BuyingEquipment] Oxygen Max Increased");
    }
}
