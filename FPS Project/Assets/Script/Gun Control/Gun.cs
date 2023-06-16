using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun :MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
   [SerializeField] protected Camera fpsCam;
   [SerializeField] protected float fireRate;
   [SerializeField] protected float timeInterval;
   [SerializeField] protected Transform shootPoint;
   [SerializeField] protected ParticleSystem impactPrefab;
    protected void Shoot()
    {
        impactPrefab.Play();
          RaycastHit hit;
        var isCollide=Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit,range);
        if(isCollide)
        {
            var target = hit.transform.GetComponent<Enemy>();
            if(target != null)
            {
            target.TakeDamage(damage);
            }
        }
    }
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (Input.GetButton("Fire1")&&fireRate<=0)
        {
            Debug.Log(Time.time);
            fireRate = timeInterval;
            Shoot();
        }
    }
}
