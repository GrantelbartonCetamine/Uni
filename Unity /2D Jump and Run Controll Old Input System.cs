
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float jumpheight = 10f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private bool EnableDobbleJump = true;

    private int MaxJumpCounter = 2;
    private int JumpCounter = 0;
    private bool isgrounded = false;
    private Rigidbody2D player;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMovement();
        Jump();
        DobbleJump();
    }

    void HorizontalMovement()
    {
        float direction = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(direction * playerspeed, player.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.velocity = new Vector2(direction * sprintSpeed, player.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isgrounded == true)
            {
                player.velocity = new Vector2(player.velocity.x, jumpheight);
                JumpCounter = 1;
                isgrounded = false;
            }

            else if (EnableDobbleJump && JumpCounter < MaxJumpCounter)
            {
                player.velocity = new Vector2(player.velocity.x, jumpheight);
                JumpCounter++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
        JumpCounter = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isgrounded = false;
    }


    void DobbleJump()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnableDobbleJump = !EnableDobbleJump;
        }
    }
}

