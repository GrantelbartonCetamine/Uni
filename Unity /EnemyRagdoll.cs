
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{

    private Rigidbody[] Enemy;
    private Animator Animator;

    void Start()
    {
        Enemy = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();

        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        Animator.enabled = false;
        foreach (Rigidbody rig in Enemy)
        {
            rig.useGravity = true;
        }
    }

    public void DisableRagdoll()
    {
        Animator.enabled = true;
        foreach (Rigidbody rig in Enemy)
        {
            rig.useGravity = false;
        }
    }
}
