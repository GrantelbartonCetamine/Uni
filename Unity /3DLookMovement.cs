using UnityEngine;
using UnityEngine.InputSystem;

public class Player3DMovement : MonoBehaviour
{

    public Rigidbody Player;
    private Player3dControlls Move;
    private Vector3 playerVelocity;

    public float RaycastSize = 10f;
    public int GroundLayer = 1 << 6;
    public float JumpHeight = 10f;
    public float MovementSpeed = 20f;
    public float SprintSpeed = 25f;

    //CameraSettings
    public Transform CharackterCamera;
    public float MouseSensitivity = 2f;
    private float XRotation = 0;
    public float LookSensitivity = 2f;

    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Move = new Player3dControlls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Controlls();
        Jump();
        LookAround();
    }

    private void LookAround()
    {
        Vector2 mouseInput = Move.Look.CemeraActions.ReadValue<Vector2>() * LookSensitivity * Time.deltaTime;

        XRotation -= mouseInput.y;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        CharackterCamera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        Player.transform.Rotate(Vector3.up * mouseInput.x);
    }

    void Controlls()
    {
        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        bool sprint = Move.SprintMap.SprintActions.IsPressed();

        Vector3 forward = CharackterCamera.forward;
        Vector3 right = CharackterCamera.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * input.y + right * input.x).normalized;
        float speed = sprint ? SprintSpeed : MovementSpeed;

        playerVelocity = direction * speed;
        Player.velocity = new Vector3(playerVelocity.x, Player.velocity.y, playerVelocity.z);
        
    }

    void Jump()
    {
        if (IsGrounded() && Move.JumpMap.Jump.WasPressedThisFrame())
        {
            Player.velocity = new Vector3(Player.velocity.x, JumpHeight, Player.velocity.z);
        }
    }

    private bool IsGrounded()
    {

        Vector3 RayOrigin = Player.transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(RayOrigin, Vector3.down, out RaycastHit hit, RaycastSize, GroundLayer))
        {
            Debug.DrawRay(RayOrigin, Vector3.down * RaycastSize, Color.green);
            Debug.Log("IsGrounded");
            return true;
        }
        else
        {
            Debug.DrawRay(RayOrigin, Vector3.down * RaycastSize, Color.red);
            Debug.Log("IsNotGrounded");
            return false;
        }
    }

    private void OnEnable()
    {
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
    }
}
