using UnityEngine;

public class My3DMovement : MonoBehaviour
{
    [SerializeField] float PlayerSprintSpeed = 20f;
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float JumpHeight = 15f;
    [SerializeField] float RaycastSize = 10f;

    private CharackterMovement Move;
    private Vector3 ForceDirection = Vector3.zero;
    private int GroundLayer = 1<<6;
    private float DoJump;

    Rigidbody Player;


    void Start()
    {

    }

    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Move = new CharackterMovement();
        DoJump = Move.JumpMap.Jump.ReadValue<float>();
    }

    private void FixedUpdate()
    {


    }

    void CharackterControlls()
    {
        Vector3 move = Move.MovementMap.Movement.ReadValue<Vector3>();
        float sprint = Move.SprintMap.Sprint.ReadValue<float>();

        if (sprint > 0)
        {
            Player.velocity = new Vector3(move.x * PlayerSprintSpeed, Player.velocity.y, move.z * PlayerSprintSpeed);
        }
        else
        {
            Player.velocity = new Vector3(move.x * PlayerSpeed, Player.velocity.y, move.z * PlayerSpeed);
        }

    }

    private void Update()
    {
        CharackterControlls();
        IsGrounded();
        Jump();
    }
    
    void Jump()
    {
        if (IsGrounded() && Move.JumpMap.Jump.WasPressedThisFrame()) 
        {
            Player.velocity = new Vector3(Player.velocity.x , JumpHeight, Player.velocity.z);
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
