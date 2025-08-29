using UnityEngine;

public class textUpDown : MonoBehaviour
{
    private float upDownCurrnet;
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
        upDownCurrnet = waddleStage;
        transform.localPosition = new Vector3(0f, upDownCurrnet*0.1f, 0f);
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
