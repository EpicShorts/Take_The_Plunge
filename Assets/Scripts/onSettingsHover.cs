using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class onSettingsHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float rotationCurrent;

    private bool hovered;

    [SerializeField] private GameObject SettingsCog;

    [SerializeField] private AudioClip SettingsInHoverMusic;
    [SerializeField] private AudioClip SettingsOutHoverMusic;

    [SerializeField] private AudioSource audioSource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverStart();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverEnd();
    }

    private void OnHoverStart()
    {
        Debug.Log("Settings Hover started!");
        hovered = true;
        audioSource.PlayOneShot(SettingsInHoverMusic);
    }

    private void OnHoverEnd()
    {
        Debug.Log("Settings Hover ended!");
        hovered = false;
        //audioSource.PlayOneShot(SettingsOutHoverMusic);
    }

    public void SettingsTab()
    {
        Debug.Log("Settings");
    }

    void Update()
    {
        CogSpin();
    }

    void CogSpin()
    {
        if (hovered)
        {
            rotationCurrent = rotationCurrent + 0.1f;
            //Debug.Log("rotationCurrent: " + rotationCurrent);
            SettingsCog.transform.localRotation = Quaternion.Euler(0f, 90f, rotationCurrent);
        }
    }
}
