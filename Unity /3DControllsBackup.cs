    private 3D
    private Rigidbody Player;
    private Vector3 PlayerVelocity;

    public float RaycastSize = 10f;
    public int GroundLayer = 1 << 6;
    public float JumpHeight = 10f;
    public float movementSpeed = 20f;

    void Start()
    {
        Move = new CharackterMovement();
        Player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Controlls();
        Jump();
    }

    void Controlls()
    {
        Vector3 input = Move.MovementMap.Movement.ReadValue<Vector3>();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        PlayerVelocity = direction * movementSpeed;

        Vector3 velocityChange = PlayerVelocity - Player.velocity;
        velocityChange.y = 0f; // Ignoriere die vertikale Geschwindigkeit

        // Begrenze die maximale Geschwindigkeitsänderung
        float maxForce = 10f; // Beispielwert
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxForce);

        Player.AddForce(velocityChange, ForceMode.Force);
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
