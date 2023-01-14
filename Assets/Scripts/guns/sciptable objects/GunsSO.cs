using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunsSO : ScriptableObject
{
    public GameObject bullet;
    public float fireRate, bulletSpeed;
    public Color color;
}
