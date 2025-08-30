using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using UnityEngine.UI;

public class gotonextscene : MonoBehaviour
{
    public Image fadeImage;
    public Image ImageFadeBlackToNormal;
    public GameObject imagefade;

    public bool starting = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeIn(1f));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonstartcall()
    {
        starting = true;
        StartCoroutine(FadeOutQuick());
        //SceneManager.LoadScene("Ice lake with hole");
    }

    private IEnumerator FadeOutQuick()
    {
        float currentTimeT = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1);

        while (currentTimeT < 2f)
        {
            currentTimeT += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, currentTimeT / 2f);
            yield return null;
        }
        fadeImage.color = endColor;

        SceneManager.LoadScene("Ice lake with hole");
    }

    private IEnumerator FadeIn(float durationOfFade)
    {
        float currentTimeT = 0f;
        Color startColor = ImageFadeBlackToNormal.color;
        Color endColor = new Color(0, 0, 0, 0);

        while (currentTimeT < durationOfFade)
        {
            currentTimeT += Time.deltaTime;
            ImageFadeBlackToNormal.color = Color.Lerp(startColor, endColor, currentTimeT / durationOfFade);
            yield return null;
        }
        ImageFadeBlackToNormal.color = endColor;
        //ImageFadeBlackToNormal.Des
        imagefade.SetActive(false);
        //firstPersonController.gameOver = false;
    }
}
