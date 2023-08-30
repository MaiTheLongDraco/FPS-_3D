using DG.Tweening;
using UnityEngine;

public class Sit : MonoBehaviour
{
    [SerializeField] private Transform SitTran;
    [SerializeField] private Ease _mShift = Ease.Linear;
    [SerializeField] private Transform camTRan;
    [SerializeField] private Transform gunTran;
    [SerializeField] private Vector3 originCamTRan;
    [SerializeField] private Vector3 originGunTran;


    [SerializeField] private float timeSit;
    private void Start()
    {
        originCamTRan = camTRan.position;
        originGunTran = gunTran.position;
    }

    public void SitDown()
    {
        MoveToSitPos(camTRan);
        MoveToSitPos(gunTran);
    }
    private void MoveToSitPos(Transform moveTran)
    {
        moveTran.transform.DOMoveY(SitTran.position.y, timeSit, true).SetEase(_mShift);
    }
    private void MoveToOriginPos(Transform moveTran, Vector3 originTran)
    {
        Debug.Log($"Original pos: {originTran.y} --- MoveTran pos: {moveTran.position.y}");
        moveTran.transform.DOMoveY(originTran.y, timeSit, true);
    }
    public void BackToOriginPos()
    {
        MoveToOriginPos(camTRan, originCamTRan);
        MoveToOriginPos(gunTran, originGunTran);

    }
}
