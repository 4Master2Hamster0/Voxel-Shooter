using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponType WhatFiredBullet;

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    public float GetBonusDamage() {
        BulletSO bulletSO = ReferenceManager.Instance.BulletSO;

        return Random.Range(bulletSO.MinBonusDmg, bulletSO.MaxBonusDmg);
    }

    public float GetDamage() {
        float dmg = 0;

        switch (WhatFiredBullet)
        {
            case WeaponType.AK47: 
                dmg = Random.Range(ReferenceManager.Instance.Ak.MinDmg, ReferenceManager.Instance.Ak.MaxDmg);
                break;

            case WeaponType.PISTOLE:
                dmg = Random.Range(ReferenceManager.Instance.Pistole.MinDmg, ReferenceManager.Instance.Pistole.MaxDmg);
                break;
        }

        return dmg;
    }
}
