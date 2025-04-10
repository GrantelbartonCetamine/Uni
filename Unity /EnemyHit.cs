using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShootableObject
{
    public EnemyRagdoll EnemyRagdoll;
    public GameObject ParticlePrefab;
    public float ImpactForce;

    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(ParticlePrefab , hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal) , transform.root.parent.transform);    
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();   

        if (particleSystem)
        {
            particleSystem.startColor = Color.red;    
        }
        EnemyRagdoll.EnableRagdoll();
        GetComponent<Rigidbody>().AddForceAtPosition(hit.transform.forward * ImpactForce , hit.point);
        Destroy(particleSystem, 2f);
    }

}
