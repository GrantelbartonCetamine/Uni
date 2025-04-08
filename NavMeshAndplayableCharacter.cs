using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmyManMovement : MonoBehaviour
{

    [Header("SceneStuff")]
    public Transform PlayerCamera;
    public NavMeshAgent ArmyGuy;
    public Rigidbody Player;
    private PlayerMovementControlls PlayerControlls;
    private ArmyManMovement ArmyPlayerMovement;

    [Header("SwitchMode")]
    public bool SwitchToPlayerMode = false;

    [Header("SpeedVars")]
    public float PlayerSpeed = 15f;
    public float SprintSpeed = 10f;

    [Header("Destinations")]
    public Transform[] PlayerDestination;

    [Header("MovementVars")]
    private float RotationXAxis = 0;
    public float MouseSensivity = 2f;

    void Start()
    {

    }
    private void Awake()
    {
        ArmyGuy = GetComponent<NavMeshAgent>();
        Player = GetComponent<Rigidbody>();
        PlayerControlls = new PlayerMovementControlls();
    }

    void Update()
    {
        SwitchMode();
    }

    private void SwitchMode()
    {
        if (SwitchToPlayerMode)
        {
            PlayerMovement();
        }

        else if (!SwitchToPlayerMode)
        {
            NavMeshBot();
        }
    }

    private void NavMeshBot()
    {
        if (!SwitchToPlayerMode)
        {

        }
    }

    private void PlayerMovement()
    {
        if (SwitchToPlayerMode)
        {
            Vector3 input = PlayerControlls.MovementMap.MoveActions.ReadValue<Vector3>();
            bool sprint = PlayerControlls.SprintMap.SprintActions.IsPressed();
            Vector2 mouseInput = PlayerControlls.LookAround.CameraLookAround.ReadValue<Vector2>() * MouseSensivity * Time.deltaTime;

            Cursor.lockState = CursorLockMode.Locked;

            Vector3 forward = PlayerCamera.forward;
            Vector3 right = PlayerCamera.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 direction = (forward * input.y + right * input.x).normalized;
            float playerSpeed = sprint ? SprintSpeed : PlayerSpeed;

            Vector3 playerVelocity = direction * playerSpeed;
            Player.velocity = new Vector3(playerVelocity.x, Player.velocity.y, playerVelocity.z);

            RotationXAxis -= mouseInput.y;
            RotationXAxis = Mathf.Clamp(RotationXAxis, -90f, 90f);

            PlayerCamera.localRotation = Quaternion.Euler(RotationXAxis, 0f, 0f);
        }
    }
}
