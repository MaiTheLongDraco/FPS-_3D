using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(AmmoSystem))]
public class Gun : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected Camera fpsCam;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float timeInterval;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected ParticleSystem impactPrefab;
    [SerializeField] protected RawImage _crossHair;
    [SerializeField] private UnityEvent onShoot;
    public UnityEvent OnShoot { get => onShoot; set => onShoot = value; }
    public bool IsOutOfAmmo;
    public Transform testLookAT;
    private void Start()
    {
    }
    private void Update()
    {
        // LookAtCenter();
    }
    protected void Shoot()
    {
        impactPrefab.Play();
        OnShoot?.Invoke();
        RaycastHit hit;
        var isCollide = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
        if (isCollide)
        {
            _crossHair.color = Color.red;
            StartCoroutine(ResetCrosshairColor());
            var target = hit.transform.GetComponent<Enemy>();

            Debug.Log(target.IsUnityNull());
            if (target != null)
            {
                target.SetState(target._isAttack);
                target.TakeDamage(damage);
            }
        }
    }
    IEnumerator ResetCrosshairColor()
    {
        yield return new WaitForSeconds(.5f);
        _crossHair.color = Color.white;
    }
    public void HandleShootInteval()
    {
        if (IsOutOfAmmo)
            return;
        fireRate -= Time.deltaTime;
        if (Input.GetButton("Fire1") && fireRate <= 0)
        {
            print("Shoot");
            fireRate = timeInterval;
            Shoot();
        }
    }
    public void ReloadAmmo()
    {
        this.GetComponent<AmmoSystem>().ReLoadAmmoBtn();
    }
    private void LookAtCenter()
    {
        print($"Loook at");
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        transform.DOLookAt(worldCenter, .5f);
    }
}
