using TMPro;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputHandler playerInputHandler;
    [SerializeField] private Transform rightHandLocation;

    [Header("Custom")]
    [Tooltip("The higher then the object feels heavier")] [SerializeField] private float heavyFeeling = 0.5f;

    private bool followingRightHand = false;

    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followingRightHand)
        {
            //transform.position = rightHandLocation.position;
            //transform.rotation = rightHandLocation.rotation;

            //transform.position = Vector3.MoveTowards(transform.position, rightHandLocation.position, 1*Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, rightHandLocation.position, ref velocity, heavyFeeling);
            transform.rotation = Quaternion.Slerp(transform.rotation, rightHandLocation.rotation, 1f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand") && !followingRightHand)
        {
            //Debug.Log("[PickupableObject] Right Hand Colliding");
            if (playerInputHandler.InteractTriggered)
            {
                Debug.Log("[PickupableObject] Picked up");
                followingRightHand = true;
            }
        }
        else
        {
            //Debug.Log("[PickupableObject] Unknown object: "+other.name);
        }

            
    }
}
