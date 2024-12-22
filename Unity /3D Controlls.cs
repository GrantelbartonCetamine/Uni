using UnityEngine;
using UnityEngine.InputSystem;

public class My3DMovement : MonoBehaviour
{
    [SerializeField]
    float PlayerSprintSpeed = 20f;

    [SerializeField]
    float PlayerSpeed = 10f;

    [SerializeField]
    float JumpHeight = 15f;

    [SerializeField]
    float RaycastSize = 10f;

    [SerializeField]
    float JumpForce = 5f;

    [SerializeField]
    float MovementForce = 5f; // Stärke der Rotation

    [SerializeField]
    float MaxSpeed = 5f; // Maximale Geschwindigkeit weil typ im youtube video meint das ist gut

    private Rigidbody Player;
    private CharackterMovement Move;

    private Vector3 ForceDirection = Vector3.zero;
    private Camera playerCamera;

    private int GroundLayer = 1 << 6;

    private float DoJump;

    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Move = new CharackterMovement();

        playerCamera = Camera.main;
        DoJump = Move.JumpMap.Jump.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        PlayerControlls();
    }

    private void Update()
    {
        Jump();
        Sprint();
    }

    void PlayerControlls()
    {
        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        ForceDirection += input.x * GetCameraRight(playerCamera) * (MovementForce);      // Set camera Movement
        ForceDirection += input.y * GetCameraForward(playerCamera) * MovementForce;    // Set camera Movement

        Player.AddForce(ForceDirection, ForceMode.Impulse);// Because of this Line the Player dont stop Moving abrupt because i always have an ForceMode.Impuls in the forcedirection when Player is Moving
        ForceDirection = Vector3.zero;

        if (Player.velocity.y < 0f)
        {
            Player.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime; // if Player fall from heights it dont stops abrupt because i dont have a static fall value , this line of code checks if the player
                                                                                       // falls down and if yes it 'Simulate' Physics so the fall is smooth and not abrupt
        }

        // Begrenze die horizontale Geschwindigkeit
        Vector3 horizontalVelocity = Player.velocity;
        horizontalVelocity.y = 0; // Setze y auf 0 
        if (horizontalVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            Player.velocity = horizontalVelocity.normalized * MaxSpeed + Vector3.up * Player.velocity.y;
        }

        // Spieler ausrichten
        LookAt();
    }

    void Sprint()
    {   
        float sprint = Move.SprintMap.Sprint.ReadValue<float>();
        if (sprint > 0)
        {
            MovementForce = PlayerSprintSpeed;
        }
        else {

            MovementForce = PlayerSpeed;

        }
    }

    private void LookAt()
    {
        Vector3 direction = Player.velocity;
        direction.y = 0f; // Nur horizontale Richtung verwenden

        if (direction.sqrMagnitude > 0.1f) // sqrMagnitude squares each Vector to the Power of 2 so sqrMagnitude is = sqrt(X**2 , Y**2 , Z**2) so if sqrMagnituded > 0.1f checks if the player is even moving
        {
            Player.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            Player.angularVelocity = Vector3.zero; // Stop RotateMovement when no movement is there because Vector3 is Zero
        }
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = camera.transform.forward; //If Camera look forward Vector3 is (0,0,1) 
        forward.y = 0; // Set to 0 because we dont want vertical Movement on ForwardCamera because we only want movement on X and Z Axis
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = camera.transform.right; //If Camera look to Left or Right Vector3 is (1, 0, 0)
        right.y = 0; // Set to 0 because we dont want vertical Movement on RightCamera because we only want movement on X and Z Axis
        return right.normalized; // normalize to make it smooth
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
