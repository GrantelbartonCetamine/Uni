using UnityEngine;

public class My3DMovement : MonoBehaviour
{
    [SerializeField] float PlayerSprintSpeed = 20f;
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float JumpHeight = 15f;



    Rigidbody Player;

    private CharackterMovement Move;
    private Vector3 ForceDirection = Vector3.zero;



    void Start()
    {
        
    }

    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Move = new CharackterMovement();


    }

    private void FixedUpdate()
    {
        CharackterControlls();

    }

    void CharackterControlls()
    {
        Vector3 move = Move.MovementMap.Movement.ReadValue<Vector3>();
        float sprint = Move.SprintMap.Sprint.ReadValue<float>();
        
        if (sprint > 0)
        {
            Player.velocity = new Vector3(move.x * PlayerSprintSpeed, Player.velocity.y,  move.z * PlayerSprintSpeed);
        }
        else
        {
             Player.velocity =  new Vector3(move.x * PlayerSpeed, Player.velocity.y , move.z * PlayerSpeed);
        }

    }



    void Jump()
    {
        if (IsGrounded())
        {
            ForceDirection += Vector3.up * JumpHeight
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(Player.transform * Vector3.up * 0.5, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit))
            return true;
        else 
            return false;

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
