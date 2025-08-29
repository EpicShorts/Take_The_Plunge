using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonHoverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject arrowMeshes;

    [SerializeField] private AudioClip MenuInHoverMusic;
    [SerializeField] private AudioClip MenuOutHoverMusic;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

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
        Debug.Log("Hover started!");
        arrowMeshes.SetActive(true);
        audioSource.PlayOneShot(MenuInHoverMusic);
        // Your logic for when hovering begins
    }

    private void OnHoverEnd()
    {
        Debug.Log("Hover ended!");
        arrowMeshes.SetActive(false);
        audioSource.PlayOneShot(MenuOutHoverMusic);
        // Your logic for when hovering stops
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Ice lake with hole");
    }
}
