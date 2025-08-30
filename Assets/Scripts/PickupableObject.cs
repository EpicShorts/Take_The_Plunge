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
    [SerializeField] private Transform mainCamera;

    [Header("Penguin")]
    [SerializeField] private PlayerWaddle playerWaddleScript;


    [Header("Game Variables")]
    //[Tooltip("The higher then the object feels heavier")] [SerializeField] private float heavyFeeling = 0.5f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private int valueWorth = 10;

    private bool followingRightHand = false;

    private bool canDrop = false;
    private bool canPickup = true;

    private bool objectInHand = false;

    private Rigidbody rb;

    public bool firstPickup = false;

    private bool hasSold = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (followingRightHand)
        {
            // move towards right hand location
            // if close, just keep next to it
            if (objectInHand)
            {
                transform.position = rightHandLocation.position;
                transform.rotation = rightHandLocation.rotation;
            }
            else
            {
                float distanceBetweenHandAndObject = Vector3.Distance(transform.position, rightHandLocation.position);
                if (distanceBetweenHandAndObject < 0.1f)
                {
                    objectInHand = true;
                }
                // if far, slowly bring closer
                else
                {
                    transform.position = Vector3.Lerp(transform.position, rightHandLocation.position, 0.05f);
                    transform.rotation = rightHandLocation.rotation;
                }
            }
            // if player drops the cube
            if (playerInputHandler.InteractTriggered && canDrop)
            {
                playerWaddleScript.PenguinDroppSound();
                DropObject();

                // throw the object
                rb.AddForce(mainCamera.forward * throwForce, ForceMode.Impulse);
                //rb.AddTorque(mainCamera.right, ForceMode.Impulse);
                //rb.AddTorque(mainCamera.up, ForceMode.Impulse);
                Debug.Log("[PickupableObject]" + gameObject.name + " has been dropped");
            }
        }
    }
    // make sure only one object can be placed in the right hand
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("[PickupableObject]" + gameObject.name + " has collided with something");

        // if object is right hand
        if (other.gameObject.CompareTag("RightHand") 
                && !followingRightHand 
                && playerInputHandler.InteractTriggered 
                && !objectHandling.IsRightHandTaken
                && canPickup) {
            // if right hand, and not currently holding it, and not taken, and user presses e
            Debug.Log("[PickupableObject]"+gameObject.name+" has been picked up");
            //playerWaddleScript.ObjectInHand = true;
            //followingRightHand = true;
            canDrop = false;
            //rb.useGravity = false;
            //objectHandling.IsRightHandTaken = true;
            //canPickup = false;
            firstPickup = true;

            //objectInHand = true;
            // silly
            followingRightHand = true;
            rb.useGravity = false;
            objectHandling.IsRightHandTaken = true;
            canPickup = false;
            objectInHand = true;
            playerWaddleScript.ObjectInHand = true;

            playerWaddleScript.PenguinPickUpSound();
            StartCoroutine(dropDelay());
        } 

        if (other.gameObject.CompareTag("ShopSell") && !hasSold)
        {
            shopSell.AddToBalence(valueWorth);
            hasSold = true;
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
        objectInHand = false;
        playerWaddleScript.ObjectInHand = false;
        StartCoroutine(pickupDelay());
    }
}
