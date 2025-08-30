using UnityEngine;

public class fishMoving : MonoBehaviour
{
    [SerializeField] private PickupableObject fishHost;
    public bool ifCaught = false;
    private float rotationCurrent = 0;
    //private bool gravityChanged = false;
    [SerializeField] private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rotationCurrent = transform.rotation.y * 360;
        //Debug.Log("[fishMoving] rotationCurrent: "+rotationCurrent);
    }

    // Update is called once per frame
    void Update()
    {
        ifCaught = fishHost.firstPickup;
        if (!ifCaught)
        {
            rotationCurrent = rotationCurrent + 10*Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, -rotationCurrent, 0f), 0.1f);
        }
        //if (ifCaught && !gravityChanged)
        //{
        //    gravityChanged = true;
        //    rb.useGravity = true;
        //}
    }
}
