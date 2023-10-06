using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _shootRange;
    [SerializeField] private int _damage;
    [SerializeField] private float E_shootInterval;
    [SerializeField] private float max_shootInterval;
    [SerializeField] public ParticleSystem impactPrefab;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _bulletSpeed;
    private void Shoot()
    {
        HandlePLayEffect();
        HandleForBullettrai(_player);
        RaycastHit hit;
        var dir = _player.transform.position - transform.position;
        var isHitPlayer = Physics.Raycast(transform.position, dir, out hit, _shootRange);
        if (isHitPlayer)
        {


            var player = hit.transform.GetComponent<PlayerHeath>();
            if (player)
            {
                player.TakeDamage(_damage);
                StartCoroutine(player.SplashScreenHandle());
            }
        }
    }
    public void DelayShooting()
    {
        var player = _player.gameObject.GetComponent<PlayerHeath>();
        E_shootInterval -= Time.deltaTime;
        //   StartCoroutine(player.SplashScreenHandle());

        var EnemyParent = GetComponentInParent<Enemy>();
        bool isAtkState = EnemyParent.States == Enemy.State.ATTACK_STATE;
        if (isAtkState && E_shootInterval <= 0)
        {
            Debug.LogAssertion(E_shootInterval + "E_shootInterval");
            Shoot();
            EnemyParent.PlayShootSound();
            E_shootInterval = max_shootInterval;
        }
    }
    private void Awake()
    {
        E_shootInterval = max_shootInterval;
        impactPrefab.transform.position = transform.position;
        impactPrefab.Stop();
        Debug.LogAssertion(E_shootInterval + "E_shootInterval");

    }
    private void HandlePLayEffect()
    {
        if (E_shootInterval <= 0)
        {
            impactPrefab.Play();
        }
        else
        {
            impactPrefab.Stop();

        }
    }
    private void HandleForBullettrai(Transform _playerTranform)
    {
        var trail = CreateBulletTrail().gameObject;
        var _rb = trail.GetComponent<Rigidbody>();
        var direction = _playerTranform.position - transform.position;
        //  trail.transform.position = Vector3.MoveTowards(trail.transform.position, _playerTranform.position,0.1f);
        _rb.AddForce(direction * _bulletSpeed);
        Destroy(trail, max_shootInterval);
    }
    private TrailRenderer CreateBulletTrail()
    {
        var trailToGet = Instantiate(_bulletTrail, transform.position, transform.rotation);
        var trail = trailToGet.GetComponent<TrailRenderer>();
        return trail;
    }
}
