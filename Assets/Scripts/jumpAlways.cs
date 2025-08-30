using UnityEngine;

public class jumpAlways : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("jump", (Random.value*2f), 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void jump()
    {
        rb.AddForce(transform.up * 6f, ForceMode.Impulse);
        rb.AddTorque(Vector3.up * 40f * Random.value, ForceMode.Force);
        audioSource.Play();
    }
}
