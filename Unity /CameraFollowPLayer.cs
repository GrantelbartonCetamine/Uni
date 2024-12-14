using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{

    [SerializeField] Transform CameraTarget;
    [SerializeField] float CameraFollowSpeed = 10f;
    [SerializeField] float CameraRotationSpeed = 5f;

    private Vector3 CameraOffset;
    private Quaternion rotation;


    void Start()
    {
        CameraOffset = transform.position - CameraTarget.position;
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        CameraFollow();
        CameraRotaion();

    }

    void CameraFollow()
    {
        Vector3 TargetPosition = CameraTarget.position + CameraTarget.rotation * CameraOffset;
        transform.position = Vector3.Lerp(transform.position, TargetPosition, CameraFollowSpeed * Time.deltaTime);
    }

    void CameraRotaion()
    {
        Quaternion rotation = Quaternion.LookRotation(CameraTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation ,rotation , CameraFollowSpeed * Time.deltaTime);
    }
}
