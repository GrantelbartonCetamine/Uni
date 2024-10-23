using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float cameraFollowSpeed = 2f;


    public Transform playerTransform;

    void Update()
    {

        Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -20f);
        transform.position = Vector3.Slerp(transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
    }
}
