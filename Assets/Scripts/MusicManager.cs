using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSourceSurface;
    [SerializeField] private AudioSource musicSourceOcean;
    [SerializeField] private AudioSource musicSourceDeepDark;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AboveMusicToggle()
    {
        StartCoroutine(fadeMusicIn(musicSourceSurface));
        StartCoroutine(fadeMusicOut(musicSourceOcean));
    }

    public void OceanMusicToggle()
    {
        StartCoroutine(fadeMusicOut(musicSourceSurface));
        StartCoroutine(fadeMusicIn(musicSourceOcean));
    }

    public void DeepDarkInto()
    {
        StartCoroutine(fadeMusicOut(musicSourceOcean));
        StartCoroutine(fadeMusicIn(musicSourceDeepDark));
    }

    public void DeepDarkOuto()
    {
        StartCoroutine(fadeMusicIn(musicSourceOcean));
        StartCoroutine(fadeMusicOut(musicSourceDeepDark));
    }

    public void DeathOutro()
    {
        StartCoroutine(fadeMusicOut(musicSourceDeepDark));
        StartCoroutine(fadeMusicOut(musicSourceOcean));
        StartCoroutine(fadeMusicOut(musicSourceSurface));
    }

    private IEnumerator fadeMusicIn(AudioSource music)
    {
        float Volume = music.volume;  
        for (int i = 0; i<100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Volume = Volume + 0.01f;
            music.volume = Volume;
        }
        Volume = 1f;
        music.volume = Volume;
    }

    private IEnumerator fadeMusicOut(AudioSource music)
    {
        float Volume = music.volume;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Volume = Volume - 0.01f;
            music.volume = Volume;
        }
        Volume = 0f;
        music.volume = Volume;
    }
}
