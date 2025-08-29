using UnityEngine;
using UnityEngine.Audio;

public class textWobble : MonoBehaviour
{
    private float rotationCurrent;
    private int waddleStage = 0;
    private bool waddleLeft = false;
    private int waddleBound = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("waddleValue", 0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        rotationCurrent = waddleStage;
        transform.localRotation = Quaternion.Euler(rotationCurrent-90f, 0f, 0f);
    }
    void waddleValue()
    {
        if (waddleLeft)
        {
            waddleStage++;
        }
        else
        {
            waddleStage--;
        }
        if (waddleStage == -waddleBound)
        {
            waddleLeft = true;
        }
        else if (waddleStage == waddleBound)
        {
            waddleLeft = false;
        }
    }
}
