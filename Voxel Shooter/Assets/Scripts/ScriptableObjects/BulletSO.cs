using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 1)]
[System.Serializable]
public class BulletSO : ScriptableObject
{
    //private variables
    [SerializeField] private GameObject _bullet; //TODO: referovat jako skript, ne jako GameObject
    [SerializeField] private float _speed, _minBonusDmg, _maxBonusDmg;

    //getters for those private variables
    public GameObject Bullet => _bullet;
    public float Speed => _speed;
    public float MinBonusDmg => _minBonusDmg;
    public float MaxBonusDmg => _maxBonusDmg;

}