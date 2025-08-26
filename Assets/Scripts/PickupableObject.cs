using TMPro;
using UnityEngine;
using System.Collections;

public class PickupableObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputHandler playerInputHandler;
    [SerializeField] private Transform rightHandLocation;
    [SerializeField] private ObjectHandling objectHandling;
    [SerializeField] private ShopSell shopSell;

    [Header("Game Variables")]
    [Tooltip("The higher then the object feels heavier")] [SerializeField] private float heavyFeeling = 0.5f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private int valueWorth = 10;

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
                DropObject();

                // throw the object
                rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                Debug.Log("[PickupableObject]" + gameObject.name + " has been dropped");
            }
        }
    }
    // make sure only one object can be placed in the right hand
    void OnTriggerStay(Collider other)
    {
        // if object is right hand
        if (other.gameObject.CompareTag("RightHand") 
                && !followingRightHand 
                && playerInputHandler.InteractTriggered 
                && !objectHandling.IsRightHandTaken
                && canPickup) {
            // if right hand, and not currently holding it, and not taken, and user presses e
            Debug.Log("[PickupableObject]"+gameObject.name+" has been picked up");
            transform.position = rightHandLocation.position;
            followingRightHand = true;
            canDrop = false;
            rb.useGravity = false;
            objectHandling.IsRightHandTaken = true;
            canPickup = false;
            StartCoroutine(dropDelay());
        } 

        if (other.gameObject.CompareTag("ShopSell"))
        {
            shopSell.AddToBalence(valueWorth);
            DropObject();
            Destroy(gameObject);
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

    private void DropObject()
    {
        followingRightHand = false;
        rb.useGravity = true;
        objectHandling.IsRightHandTaken = false;
        canPickup = false;
        StartCoroutine(pickupDelay());
    }
}
