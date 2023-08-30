using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private WeaponType _type;
    [SerializeField] private WeaponShootStyle _shootStyle;
    [SerializeField] private float _minDmg, _maxDmg;
    [SerializeField] private GameObject _prefab; 
    [SerializeField] private Vector3 _shootPointPosition;
    [SerializeField] private BulletSO _bulletSO;

    public WeaponType Type => _type;
    public WeaponShootStyle ShootStyle => _shootStyle;
    public float MinDmg => _minDmg;
    public float MaxDmg => _maxDmg;
    public GameObject WeaponPrefab => _prefab;
    public Vector3 ShootPointPosition => _shootPointPosition;
    public BulletSO BulletSO => _bulletSO;

}
