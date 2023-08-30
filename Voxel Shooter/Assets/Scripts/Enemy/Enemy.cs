using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private DifficultyDependentData _enemySO;
    [SerializeField] private float _health;  
    [SerializeField] private float _damage;  

    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemySO = ReferenceManager.Instance.DifficultyDependentData;
        _health = _enemySO.GetHealth();
        _damage = _enemySO.GetDamage();
    }
    
    void Update()
    {
        
    }

    public void DecreaseHealth(float amount) {
        _health -= amount;
        CheckHealth();
    }

    private void OnTriggerEnter(Collider other) {
        Bullet bullet = other.GetComponent<Bullet>();
        float takenDamage = 0;

        if(other.isTrigger) {

            takenDamage += bullet.GetBonusDamage() + bullet.GetDamage();
            _health -= takenDamage;

            CheckHealth();
        }
    }

    private void CheckHealth() {
        if(_health <= 0) {
            GetComponent<EnemyMovement>().enabled = false;
            _animator.SetTrigger("die");
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
