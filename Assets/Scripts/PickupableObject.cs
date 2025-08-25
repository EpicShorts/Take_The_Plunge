using TMPro;
using UnityEngine;
using System.Collections;

public class PickupableObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputHandler playerInputHandler;
    [SerializeField] private Transform rightHandLocation;
    [SerializeField] private ObjectHandling objectHandling;

    [Header("Custom")]
    [Tooltip("The higher then the object feels heavier")] [SerializeField] private float heavyFeeling = 0.5f;
    [SerializeField] private float throwForce = 10f;

    private bool followingRightHand = false;

    private bool canDrop = false;
    private bool canPickup = true;

    private Vector3 smoothDampVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (followingRightHand)
        {
            // move towards right hand location
            transform.position = Vector3.SmoothDamp(transform.position, rightHandLocation.position, ref smoothDampVelocity, heavyFeeling);
            transform.rotation = Quaternion.Slerp(transform.rotation, rightHandLocation.rotation, heavyFeeling);

            // if player drops the cube
            if(playerInputHandler.InteractTriggered && canDrop)
            {
                followingRightHand = false;
                rb.useGravity = true;
                objectHandling.IsRightHandTaken = false;
                canPickup = false;
                StartCoroutine(pickupDelay());

                // throw the object
                rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                Debug.Log("[PickupableObject]" + gameObject.name + " has been dropped");
            }
        }
    }
    // make sure only one object can be placed in the right hand
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand") 
                && !followingRightHand 
                && playerInputHandler.InteractTriggered 
                && !objectHandling.IsRightHandTaken
                && canPickup) {
            // if right hand, and not currently holding it, and not taken, and user presses e
            Debug.Log("[PickupableObject]"+gameObject.name+" has been picked up");
            followingRightHand = true;
            canDrop = false;
            rb.useGravity = false;
            objectHandling.IsRightHandTaken = true;
            canPickup = false;
            StartCoroutine(dropDelay());
        } 
    }

    IEnumerator dropDelay()
    {
        yield return new WaitForSeconds(0.3f);
        canDrop = true;
    }

    IEnumerator pickupDelay()
    {
        yield return new WaitForSeconds(0.3f);
        canPickup = true;
    }
}
