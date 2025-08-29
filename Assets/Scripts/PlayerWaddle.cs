using UnityEngine;
using UnityEngine.Audio;

public class PlayerWaddle : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private InputHandler playerInputHandler;
    [SerializeField] private Transform pengiunBelly;
    [SerializeField] private Transform pengiunLeftFoot;
    [SerializeField] private Transform pengiunRightFoot;
    [SerializeField] private FirstPersonController firstPersonController;

    [Header("Sound")]
    [SerializeField] private AudioClip snowFootstep_1;
    [SerializeField] private AudioClip snowFootstep_2;
    [SerializeField] private AudioClip penguinPickupSound;
    [SerializeField] private AudioClip penguinDropSound;
    private AudioSource audioSource;

    private int waddleStage = 0;
    private bool waddleLeft = false;
    private int waddleBound = 5;
    private bool swimMode = false;
    private bool swimModeComplete = false;

    public bool ObjectInHand = false;
    public float speedOfAnimations = 5f;
    private float currentTime = 0f;

    // Penguin arms
    [SerializeField] private Transform penguinArms;

    private Vector3 penguinArmEndPosition = new Vector3(0.03f, -0.15f, -0.65f);
    private Quaternion penguinArmEndRotation = Quaternion.Euler(56.17f, 0f, 0f);

    private Vector3 penguinArmStartPosition = new Vector3(0f, 0f, 0f);
    private Quaternion penguinArmStartRotation = Quaternion.Euler(0f, 0f, 0f);

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("waddleValue", 1f, 0.05f);
    }

    void Update()
    {
        currentTime = Time.deltaTime;

        if (transform.position.y > 0)
        {
            swimMode = false;
            swimModeComplete = false;
        }
        else
        {
            swimMode = true;
            audioSource.mute = true;
        }
        if (!swimMode)
        {
            if ((playerInputHandler.MovementInput.x != 0 || playerInputHandler.MovementInput.y != 0))
            {
                audioSource.mute = false;

                // move belly left to right
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 0f, waddleStage),
                    speedOfAnimations * currentTime);
                // move feet forwards and backwards
                Vector3 footpositionleft = new Vector3(pengiunLeftFoot.localPosition.x, pengiunLeftFoot.localPosition.y, (waddleStage * 0.01f) + 0.1f);
                Vector3 footpositionright = new Vector3(pengiunRightFoot.localPosition.x, pengiunRightFoot.localPosition.y, (waddleStage * -0.01f) + 0.1f);
                pengiunLeftFoot.localPosition = Vector3.Lerp(pengiunLeftFoot.localPosition, footpositionleft, speedOfAnimations * currentTime);
                pengiunRightFoot.localPosition = Vector3.Lerp(pengiunRightFoot.localPosition, footpositionright, speedOfAnimations * currentTime);
            }
            else
            {
                audioSource.mute = true;
            }
            if ((transform.localRotation.x > 0f))
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), speedOfAnimations * currentTime);
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, 0f, 0f), speedOfAnimations * currentTime);
            }
        }
        else
        {
            if (!swimModeComplete)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90f, 0f, 0f), speedOfAnimations * currentTime);
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, -0.2f, -0.7f), speedOfAnimations * currentTime);
                if(!(transform.localRotation.x < 90f))
                {
                    swimModeComplete = true;
                }
            }

        }

        if (ObjectInHand && penguinArms.localRotation.x > 0)
        {
            penguinArms.localRotation = Quaternion.Slerp(penguinArms.localRotation, penguinArmStartRotation, speedOfAnimations * currentTime);
            penguinArms.localPosition = Vector3.Lerp(penguinArms.localPosition, penguinArmStartPosition, speedOfAnimations * currentTime);
        }
        else if (!ObjectInHand)
        {
            penguinArms.localRotation = Quaternion.Slerp(penguinArms.localRotation, penguinArmEndRotation, speedOfAnimations * currentTime);
           penguinArms.localPosition = Vector3.Lerp(penguinArms.localPosition, penguinArmEndPosition, speedOfAnimations * currentTime);
        }
    }

    // waddlestage will 'bounce between -bound and +bound in 1 increments
    void waddleValue()
    {
        if (waddleLeft)
        {
            waddleStage++;
        }
        else
        {
            waddleStage--;
        }
        if (waddleStage == -waddleBound)
        {
            waddleLeft = true;
            audioSource.PlayOneShot(snowFootstep_1);
        }
        else if (waddleStage == waddleBound)
        {
            waddleLeft = false;
            audioSource.PlayOneShot(snowFootstep_2);
        }
    }

    public void PenguinPickUpSound()
    {
        firstPersonController.PenguinPickUpSound1();
    }
    public void PenguinDroppSound()
    {
        firstPersonController.PenguinDroppSound1();
    }
}
