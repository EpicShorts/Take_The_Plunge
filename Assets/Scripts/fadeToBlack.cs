using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadeToBlack : MonoBehaviour
{
    public Image fadeImage;
    public Image ImageFadeBlackToNormal;
    public float fadeDuration = 5f;

    [SerializeField] FirstPersonController firstPersonController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPersonController.gameOver = true;
        StartCoroutine(FadeIn(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToBlackWithScene(string sceneName, float durationOfFade)
    {
        StartCoroutine(FadeOut(sceneName, durationOfFade));
    }

    private IEnumerator FadeOut(string sceneName, float durationOfFade)
    {
        float currentTimeT = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1);

        while (currentTimeT < durationOfFade)
        {
            currentTimeT += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, currentTimeT / durationOfFade);
            yield return null;
        }
        fadeImage.color = endColor;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Loaded Scene");
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
        firstPersonController.gameOver = false;
    }

    public void FadeToBlackQuick()
    {
        StartCoroutine(FadeOutQuick());
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
    }
}
