using UnityEngine;

public class OxygenSystem : MonoBehaviour
{
    [SerializeField] public int OxygenLevel = 10;
    public bool GameOver = false;

    [Header("Game Parameters")]
    [SerializeField] public int OxygenMax = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("decreaseOxygen", 1f,1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void decreaseOxygen()
    {
        if (GameOver) return;
        if (!(transform.position.y < 0))
        {
            OxygenLevel = OxygenMax;
            return;
        }
        OxygenLevel--;
        if (OxygenLevel <= 0)
        {
            Debug.Log("[OxygenSystem] Game Over!");
            GameOver = true;
            return;
        }
        Debug.Log("[OxygenSystem] Oxygen Level: "+OxygenLevel);
    }
}
