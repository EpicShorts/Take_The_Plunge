using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystem : MonoBehaviour
{
    [SerializeField] public int OxygenLevel = 10;
    public bool GameOver = false;

    [Header("Game Parameters")]
    [SerializeField] public int OxygenMax = 10;

    [Header("Bubbles")]
    [SerializeField] private GameObject bubble_1;
    [SerializeField] private GameObject bubble_2;
    [SerializeField] private GameObject bubble_3;
    [SerializeField] private GameObject bubble_4;
    [SerializeField] private GameObject bubble_5;
    [SerializeField] private GameObject bubble_6;
    [SerializeField] private GameObject bubble_7;
    [SerializeField] private GameObject bubble_8;

    public List<GameObject> bubbles = new List<GameObject>();

    private int bubblesLength = 0;
    private float bubbleSplit;

    [SerializeField] private fadeToBlack fadeToBlackScript;

    private Vector3 stuckLocation;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private FirstPersonController firstPersonController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubblesLength = bubbles.Count;

        InvokeRepeating("decreaseOxygen", 1f,0.1f);
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
            for (int i = 0; i < bubblesLength; i++)
            {
                bubbles[i].SetActive(true);
            }
            return;
        }
        OxygenLevel--;
        if (OxygenLevel <= 0)
        {
            //Debug.Log("[OxygenSystem] Game Over!");
            GameOver = true;
            fadeToBlackScript.FadeToBlackWithScene("Death");
            stuckLocation = transform.position;
            //characterController.enabled = false;
            firstPersonController.gameOver = true;
            return;
        }

        //Debug.Log("[OxygenSystem] Oxygen Level: "+OxygenLevel);

        updateBubbles();
    }

    void updateBubbles()
    {
        bubbleSplit = OxygenMax / bubblesLength;
        // 1.2 2.4 3.6 -> 8
        // 10 9 8 7

        // this runs for 8 cycles
        for (int i = 0;  i < bubblesLength; i++)
        {
            if (OxygenLevel <= bubbleSplit * (i+1))
            {
                bubbles[i].SetActive(false);
            }
            //Debug.Log("[OxygenSystem] i value: " + i);
        }
    }
}
