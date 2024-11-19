using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float jumpheight = 10f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private bool EnableDobbleJump = true;

    private int JumpCounter = 0;
    private bool isgrounded = false;


    private Rigidbody2D player;
    private PlayerInputSystem playermovement;
    private int groundlayer = 1 << 6;

    private float Raycastsize = 2.0f;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        playermovement = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        playermovement.Enable();
    }

    private void OnDisable()
    {
        playermovement.Disable();
    }


    private void Update()
    {
        playercontrolls();
        GroundCheck();
        Jump();
        ToggleDoubleJump();
    }

    private void playercontrolls()
    {
        Vector2 mymovement = playermovement.ActionMapMovement.ActionMovement.ReadValue<Vector2>();

        if (playermovement.ActionMapMovement.Sprint.ReadValue<float>() > 0)
        {
            player.velocity = new Vector2(mymovement.x * sprintSpeed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(mymovement.x * playerspeed, player.velocity.y);
        }
    }

    private void Jump()
    {
        if (playermovement.ActionMapMovement.Jumping.WasPressedThisFrame())
        {
            if (isgrounded == true)
            {
                player.velocity = new Vector2(player.velocity.x, jumpheight);
                JumpCounter = 1;
                isgrounded = false;
                Debug.Log("Normal Jumped");
            }

            else if (EnableDobbleJump == true && JumpCounter < 2)
            {
                player.velocity = new Vector2(player.velocity.x, jumpheight);
                JumpCounter = 2;
                Debug.Log("Double Jumped");

            }
        }
    }

    void ToggleDoubleJump()
    {
        if (playermovement.ActionMapMovement.ToggleDoubleJump.WasPressedThisFrame())
        {
            EnableDobbleJump = !EnableDobbleJump;
        }
    }


    private void GroundCheck()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, Raycastsize, groundlayer);

        if (hitInfo.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * Raycastsize, Color.green);
            isgrounded = true;
            JumpCounter = 0;
            Debug.Log("Grounded");
        }
        else
        {
            isgrounded = false;
            Debug.DrawRay(transform.position, Vector2.down * Raycastsize, Color.red);
            Debug.Log("Not Grounded");
        }
    }
}
