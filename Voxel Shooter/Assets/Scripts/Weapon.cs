using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private bool _isIdeling;    
    [SerializeField] private string _clipName;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private BulletSO _bulletSO;

    private void Start() {
        Init();
        _bulletSO = ReferenceManager.Instance.WeaponSwitcher.CurrentWeaponSO.BulletSO;
    }
    
    private void Init() {
        _animator = GetComponent<Animator>();
        _clipName = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    public void PlayShootingAnimation()
    {
        if(_isIdeling && !_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals(_clipName))
        {
            _animator.SetTrigger("shoot"); 
        }
    }

    public void ShootProjectile() {
        GameObject bulletGO = Instantiate(_bulletSO.Bullet, _shootPoint.transform.position, Quaternion.identity);
        bulletGO.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.right) * _bulletSO.Speed * Time.deltaTime);
        
        bulletGO.GetComponent<Bullet>().WhatFiredBullet = WeaponSwitcher.Instance.CurrentWeaponSO.Type;

        Destroy(bulletGO, 6);
    }

}
