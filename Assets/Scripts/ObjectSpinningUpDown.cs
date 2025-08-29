using UnityEngine;

public class ObjectSpinningUpDown : MonoBehaviour
{
    private float speedOfAnimations = 5f;
    private float currentTime;

    private float rotationCurrent = 0;
    //[SerializeField] private ParticleSystem particleSystemScatter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationCurrent = transform.rotation.y * 360;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.deltaTime;

        rotationCurrent = rotationCurrent + (100 * Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, -rotationCurrent, 0f), speedOfAnimations * Time.deltaTime);
    }

    //private void OnDestroy()
    //{
    //    particleSystemScatter.Play();
    //}
}
