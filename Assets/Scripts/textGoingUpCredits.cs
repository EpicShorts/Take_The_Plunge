using UnityEngine;

public class textGoingUpCredits : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        InvokeRepeating("TextUp", 0f, 0.002f);
        //Invoke("QuitGame",20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextUp()
    {
        //if (rectTransform.position.y < 2300)
        //{
        //    rectTransform.position = new Vector3(500f, rectTransform.position.y + 0.1f, 0f);
        //}
        //ctTransform.position = new Vector3(500f,rectTransform.position.y+0.1f, 0f);
        rectTransform.position = new Vector3(560f, rectTransform.position.y + 0.1f, 0f);


    }

    void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
