using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGunInFo : MonoBehaviour
{
    [SerializeField] public string gunName;
    [SerializeField] public int gunPrice;
    [SerializeField] public GunState gunState;
}
public enum GunState
{
    UN_PURCHASED,
    EQUIPTED,
    UN_EQUIPTED
}
