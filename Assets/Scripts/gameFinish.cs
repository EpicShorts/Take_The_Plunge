using System.Collections;
using UnityEngine;

public class gameFinish : MonoBehaviour
{
    public bool gameFinished = false;

    [SerializeField] private fadeToBlack fadeToBlackScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0 && !gameFinished)
        {
            gameFinished = true;
            StartCoroutine(gameFinishWait());
        }
    }

    IEnumerator gameFinishWait()
    {
        fadeToBlackScript.FadeToBlackWithScene("Ending",5f);
        yield return new WaitForSeconds(2f);
        Debug.Log("Game done, well done");
    }
}
