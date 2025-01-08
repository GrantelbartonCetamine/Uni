using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class My3DMovement : MonoBehaviour
{
    [SerializeField]
    float PlayerSprintSpeed = 20f;

    [SerializeField]
    float PlayerSpeed = 70f;

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

    [SerializeField]
    private float RotationSmoothness = 10f; // Rotaion nicht abrupt machen


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
        OpenPauseMenu();
    }

    private void Update()
    {
        PlayerControlls();
        Jump();
        Sprint();
    }

    void PlayerControlls()
    {
        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        Vector3 moveDirection = input.x * GetCameraRight(playerCamera) + input.y * GetCameraForward(playerCamera);

        // Berechne die Geschwindigkeit basierend auf der Bewegungsrichtung
        Vector3 targetVelocity = moveDirection * MovementForce;
        
        // Setze die Y-Komponente auf die aktuelle Geschwindigkeit, damit die Schwerkraft und Sprungkräfte erhalten bleiben
        targetVelocity.y = Player.velocity.y;

        // Setze die Geschwindigkeit direkt, anstatt sie mit AddForce zu verändern
        Player.velocity = Vector3.Lerp(Player.velocity, targetVelocity, 10f * Time.deltaTime);

        // Begrenze die horizontale Geschwindigkeit (auf MaxSpeed)
        Vector3 horizontalVelocity = Player.velocity;
        horizontalVelocity.y = 0; // Setze Y-Komponente auf 0, um die vertikale Geschwindigkeit zu ignorieren
        if (horizontalVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            Player.velocity = horizontalVelocity.normalized * MaxSpeed + Vector3.up * Player.velocity.y;
        }

        LookAt(); // Orientierung des Spielers anpassen
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
        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        Vector3 moveDirection = input.x * GetCameraRight(playerCamera) + input.y * GetCameraForward(playerCamera);

        if (moveDirection.sqrMagnitude > 0.1f) // Bewegung vorhanden?
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Player.rotation = Quaternion.Slerp(Player.rotation, targetRotation, RotationSmoothness * Time.deltaTime);
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

        Vector3 RayOrigin = Player.transform.position + Vector3.up * 0.8f;

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

    public void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadSceneAsync(0);     
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
