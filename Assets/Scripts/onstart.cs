using UnityEngine;

public class onstart : MonoBehaviour
{
    bool waitover = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Invoke("lateStart",0.1f);
        //Cursor.visible = true;
    }


    void lateStart()
    {
        //waitover = true;
    }

    void Update()
    {

        //if (Cursor.lockState != CursorLockMode.Locked && Application.isFocused && waitover)
        //{
        //    LockCursor();
        //}
    }

    void LockCursor()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
}
