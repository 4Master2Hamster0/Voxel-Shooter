using UnityEngine;
using TMPro;

public class SonicWave : MonoBehaviour
{
    //Postřeh: pokud chci funkční skript navázat na UI, udělám to tak, aby nebyly na sebe závislé. Odpočet bude probíhat v tomto skriptu a skript, který bude tento 
    //odpočet převádět na viditelnou formu si vezme referenci na hráče, vezme si tento skript a naloží s ním jak jen chce. Separovat logiku a grafiku

    [SerializeField] private DifficultyDependentData _diffDependentData;
    [SerializeField] private ParticleSystem _particleSonicWave; 
    [SerializeField] private float _power;
    [SerializeField] private float _radius;
    [SerializeField] private float _upForce;
    [SerializeField] private float _damage;

    private float CurrentTime;
    private float _timerLimit = 0;
    private float _initTime = 10;
    private bool _timerHasEnded = false;

    void Start()
    {
        _particleSonicWave = GetComponentInChildren<ParticleSystem>();
        _diffDependentData = ReferenceManager.Instance.DifficultyDependentData;
        Init();
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.R) && !_particleSonicWave.isPlaying && CanCastSpell()) {
            _particleSonicWave.Play();
            CastSonicWave();
            ResetTimer();
        } 

        DecreaseTimer();
    }

    private void CastSonicWave() {
        EventManager.OnSonicWaveCasted?.Invoke(true);
        //OverlapSphere vytvoří na určitém místě kouli o určitém průměru, okamžitě vrátí všechny kolize, které se s touto koulí střetli (ať už uvnitř ní, povrchu či kraji)
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach(Collider hit in colliders) {
            if(!hit.CompareTag("Enemy")) continue;

            Rigidbody rb = hit.GetComponent<Rigidbody>();
            Enemy enemy = hit.GetComponent<Enemy>();

            rb.AddExplosionForce(_power, transform.position, _radius, _upForce, ForceMode.Impulse);
            enemy.DecreaseHealth(_damage);
        }
    }

    private void Init() {
        _damage = _diffDependentData.GetDamage();
        _power = _diffDependentData.GetSonicWavePower();
        _radius = _diffDependentData.GetSonicWaveRadius();
        _upForce = _diffDependentData.GetSonicWaveUpForce();
    }

    private void DecreaseTimer() {
        if(_timerHasEnded) return;

        CurrentTime -= Time.deltaTime;

        if(CurrentTime <= _timerLimit) {
            CurrentTime = _timerLimit;
            _timerHasEnded = true;
        }
    }

    private void ResetTimer() {
        CurrentTime = _initTime;
        _timerHasEnded = false;
    }

    private bool CanCastSpell() {
        return (CurrentTime <= _timerLimit) ? true : false;
    }

    public float GetCurrentTime() {
        return CurrentTime;
    }

    public float GetInitTime() {
        return _initTime;
    }
}
