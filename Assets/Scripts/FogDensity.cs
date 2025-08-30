using UnityEngine;

public class FogDensity : MonoBehaviour
{

    [SerializeField] private Transform playerLocation;
    [SerializeField] private GameObject directionalLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // no more than 0.1
        // 0.05
        // goes down to -300
        float fogdensityvalue = (-playerLocation.position.y * 0.0004f);
        if (fogdensityvalue >= 0 && fogdensityvalue <= 0.05f)
        {
            RenderSettings.fogDensity = fogdensityvalue;
        }
        else if (fogdensityvalue >= 0.05f)
        {
            RenderSettings.fogDensity = 0.05f;
        }
        //if (fogdensityvalue >= 0)
        //{
        //    RenderSettings.fogDensity = fogdensityvalue;
        //}
        //else
        //{
        //    RenderSettings.fogDensity = 0.014f;
        //}
        if (playerLocation.position.y < -1)
        {
            directionalLight.gameObject.SetActive(false);
        }
        else
        {
            directionalLight.gameObject.SetActive(true);
        }
    }
}
