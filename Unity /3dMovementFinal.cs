
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class My3DMovement : MonoBehaviour
{

    [SerializeField]
    float PlayerSpeed = 70f;

    [SerializeField]
    float JumpHeight = 15f;

    [SerializeField]
    float RaycastSize = 10f;

    public int GroundLayer = 1 << 6;

    private Rigidbody Player;
    private CharackterMovement Move;

    private Vector3 PlayerVelocity;

    [SerializeField] public AudioSource WalkSound;
    [SerializeField] public AudioSource JumpSound;
    [SerializeField] public AudioSource RunInsideWood;

    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Move = new CharackterMovement();
    }

    private void FixedUpdate()
    {
        OpenPauseMenu();
    }


    private void Update()
    {
        PlayerControlls();
        Jump();
    }

    private void Start()
    {
        WalkSound = GetComponent<AudioSource>();
        JumpSound = GetComponent<AudioSource>();
        RunInsideWood = GetComponent<AudioSource>();
    }

    void PlayerControlls()
    {

        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        Vector3 direction = new Vector3(input.x, 0f, input.z);
        PlayerVelocity = direction * PlayerSpeed;
        Player.velocity = new Vector3(PlayerVelocity.x, Player.velocity.y, PlayerVelocity.z);
    }

    public void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadSceneAsync(0);
        }
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
