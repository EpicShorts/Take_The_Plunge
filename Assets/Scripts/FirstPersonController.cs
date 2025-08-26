using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplayer = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float upDownLookRange = 80.0f;

    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private InputHandler playerInputHandler;

    [Header("Game Parameters")]
    [SerializeField] private float diveForce = 0.05f;
    [SerializeField] private float diveSpeed = 5f;
    [Tooltip("0 is no movement, 1 is normal")] [SerializeField] public float surfaceSpeedMultiplyer = 1f;
    [Tooltip("0 is no movement, 1 is normal")] [SerializeField] public float underWaterSpeedMultiplyer = 1f;
    [Tooltip("0 is no movement, 1 is normal")] [SerializeField] public float diveSpeedMultiplyer = 1f;

    private Vector3 currentMovement;
    private float verticalRotation;

    // if sprint triggered is true, then multiply by sprint multiplayer, if not then multiple by 1 (dont change)
    private float CurrentSpeed => walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplayer : 1);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0f, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleJumping()
    {
        // if above ground, gravity is normal
        if (transform.position.y > 0f)
        {
            if (characterController.isGrounded)
            {
                currentMovement.y = -0.5f;

                if (playerInputHandler.JumpTriggered)
                {
                    currentMovement.y = jumpForce;
                }
            }
            else
            {
                currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }
        }
        // if just about to go to the top
        if (transform.position.y < 0f)
        {
            if (playerInputHandler.SneakTriggered && currentMovement.y > -diveSpeed)
            {
                currentMovement.y += -diveForce * diveSpeedMultiplyer;
            }
            if (currentMovement.y < 10f)
            {
                currentMovement.y += Physics.gravity.y * -gravityMultiplier * Time.deltaTime * 0.5f;
            }
        }
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        if (transform.position.y >= 0)
        {
            currentMovement.x = worldDirection.x * (CurrentSpeed * surfaceSpeedMultiplyer);
            currentMovement.z = worldDirection.z * (CurrentSpeed * surfaceSpeedMultiplyer);
        }
        // if below 0, aka in water
        else
        {
            currentMovement.x = worldDirection.x * (CurrentSpeed * underWaterSpeedMultiplyer);
            currentMovement.z = worldDirection.z * (CurrentSpeed * underWaterSpeedMultiplyer);
        }

        HandleJumping();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRoation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRoation(mouseYRotation);
    }
}
