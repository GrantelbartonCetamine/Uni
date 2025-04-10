using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resources : https://www.youtube.com/watch?v=nlcIz-czKyI&list=PLrMEhC9sAD1ya9RFdnjFUL1foVlZjRkE7&index=3
public class SwayWeapon : MonoBehaviour
{

    public float Intensity;
    public float ResetPosition;

    private Quaternion OriginRotation;    // Default Rotation of Weapon    

    void Start()
    {
        OriginRotation = transform.localRotation;    
    }


    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseXAxis = Input.GetAxis("Mouse X");
        float mouseYAxis = Input.GetAxis("Mouse Y");

        // Calculate target Location:
        Quaternion TargetXAdjustment = Quaternion.AngleAxis(-Intensity * mouseXAxis, Vector3.up);
        Quaternion TargetYAdjustment = Quaternion.AngleAxis(Intensity * mouseYAxis, Vector3.right);

        Quaternion TargetRotation = OriginRotation * TargetXAdjustment * TargetYAdjustment;

        // Rotate to Target
        transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, Time.deltaTime * ResetPosition);   

    }
}
