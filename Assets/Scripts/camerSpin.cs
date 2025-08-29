using UnityEngine;

public class camerSpin : MonoBehaviour
{
    private float rotationCurrent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("NewLocation", 0f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        //rotationCurrent++;
        //Debug.Log("rotationCurrent: " + rotationCurrent);
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, rotationCurrent, 0f), speedOfAnimations * Time.deltaTime);
    }

    void NewLocation()
    {
        rotationCurrent = rotationCurrent + 0.1f;
        //Debug.Log("rotationCurrent: " + rotationCurrent);
        transform.localRotation = Quaternion.Euler(0f, rotationCurrent, 0f);
    }
}
