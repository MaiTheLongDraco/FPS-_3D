using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _shootRange;
    [SerializeField] private int _damage;
    [SerializeField] private float E_shootInterval;
    [SerializeField] public ParticleSystem impactPrefab;
    private void Shoot()
    {
        impactPrefab.Play();
        RaycastHit hit;
        var dir = _player.transform.position - transform.position;
        var isHitPlayer = Physics.Raycast(transform.position, dir,out hit, _shootRange);
        if(isHitPlayer)
        {
            var player= hit.transform.GetComponent<PlayerHeath>();
            if(player)
            {
            player.TakeDamage(_damage);
            }
        }
    }
    public void DelayShooting()
    {
        E_shootInterval -= Time.deltaTime;

        var EnemyParent = GetComponentInParent<Enemy>();
        bool isAtkState = EnemyParent.States == Enemy.State.ATTACK_STATE;
        if(isAtkState&& E_shootInterval<=0)
        {
            Shoot();
            E_shootInterval = 2f;
        }
    }
    private void Awake()
    {
        impactPrefab.transform.position = transform.position;
        impactPrefab.Stop();
    }

}
