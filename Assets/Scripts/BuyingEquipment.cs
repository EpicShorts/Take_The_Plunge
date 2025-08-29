using System.Collections;
using TMPro;
using UnityEngine;

public class BuyingEquipment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private ShopSell shopSell;
    [SerializeField] private OxygenSystem oxygenSystem;
    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem oyxgenTankParticleSystem;
    [SerializeField] private ParticleSystem flipperParticleSystem;
    [SerializeField] private ParticleSystem weightsParticleSystem;
    [Header("Text for signs")]
    [SerializeField] private TextMeshProUGUI oxygenSignText;
    [SerializeField] private TextMeshProUGUI fliipersSignText;
    [SerializeField] private TextMeshProUGUI wieghtsSignText;




    [Header("Sounds")]
    [SerializeField] private AudioClip boughtSoundEffect;
    [SerializeField] private AudioSource playerAudioSource;

    [Header("ShopKeeper")]
    //[SerializeField] private AudioSource shopKeeperAudio;
    //[SerializeField] private AudioClip happySell;
    //[SerializeField] private AudioClip noSell;
    [SerializeField] private ShopKeeper shopKeeperScript;

    private float oxygenPrice = 20;
    private float flippersPrice = 10;
    private float weightPrice = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerAudioSource.GetComponent<AudioSource>();
        updateVisualPrices();
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
                if (shopSell.RemoveFromBalence((int)flippersPrice))
                {
                    other.gameObject.SetActive(false);
                    IncreaseSwimSpeed(2f);
                    flipperParticleSystem.Play();
                    playerAudioSource.PlayOneShot(boughtSoundEffect);
                    flippersPrice = flippersPrice * 1.8f;
                    updateVisualPrices();
                    StartCoroutine(RespawnObject(other.gameObject));

                    StartCoroutine(happySellMethod());
                }
                else
                {
                    //shopKeeperAudio.PlayOneShot(noSell);
                    shopKeeperScript.shopKeeperSad();
                }
                    break;
            case "BasicWeights":
                if (shopSell.RemoveFromBalence((int)weightPrice)) 
                {
                    IncreaseDiveSpeed(0.5f);
                    other.gameObject.SetActive(false);
                    weightsParticleSystem.Play();
                    weightPrice = weightPrice * 2.7f;
                    StartCoroutine(RespawnObject(other.gameObject));
                    updateVisualPrices();
                    playerAudioSource.PlayOneShot(boughtSoundEffect);

                    StartCoroutine(happySellMethod());
                }
                else
                {
                    shopKeeperScript.shopKeeperSad();
                }
                break;
            case "BasicOxygenTank":
                if (shopSell.RemoveFromBalence((int)oxygenPrice))
                {
                    IncreaseMaxOxygenLevel(100); 
                    other.gameObject.SetActive(false);
                    oyxgenTankParticleSystem.Play();
                    playerAudioSource.PlayOneShot(boughtSoundEffect);
                    //Invoke("RespawnObject", 5);
                    //RespawnObject(other.gameObject);
                    oxygenPrice = oxygenPrice * 1.6f;
                    updateVisualPrices();
                    StartCoroutine(RespawnObject(other.gameObject));

                    StartCoroutine(happySellMethod());
                }
                else
                {
                    shopKeeperScript.shopKeeperSad();
                }
                break;
            default:
                Debug.Log("Unknown ShopBuy tag");
                break;
        }
    }
    IEnumerator RespawnObject(GameObject buyableObject)
    {
        yield return new WaitForSeconds(2);
        buyableObject.gameObject.SetActive(true);
    }

    IEnumerator happySellMethod()
    {
        yield return new WaitForSeconds(0.5f);
        shopKeeperScript.shopKeeperHappy();
    }

    private void updateVisualPrices()
    {
        oxygenSignText.text = "$"+((int)oxygenPrice).ToString();
        fliipersSignText.text = "$"+((int)flippersPrice).ToString();
        wieghtsSignText.text = "$"+((int)weightPrice).ToString();
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
