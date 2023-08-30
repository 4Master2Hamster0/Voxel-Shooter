using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private Weapon _weaponScript;
    [SerializeField] private WeaponSwitcher _weaponSwitcher;
    [SerializeField] private GameObject _bullet;
    
    private bool _canShoot;

    private void OnEnable() {
       WeaponEvent.OnWeaponSwitch.AddListener(UpdateWeapon);
       EventManager.OnEscPressed.AddListener(ChangeShootState);
    }

    private void OnDisable() {
        WeaponEvent.OnWeaponSwitch.RemoveListener(UpdateWeapon);
        EventManager.OnEscPressed.RemoveListener(ChangeShootState);
    }

    private void Start() {
        Init();
    }

    private void Init() {
        _canShoot = true; //TODO: pokud zbraň nestřílí, raději omrknout nejprve tuto proměnou a její podmínku
        _weaponSwitcher = ReferenceManager.Instance.WeaponSwitcher;
        UpdateWeapon();
    }

    private void Update()
    {
        TryShoot();        
    }

    private void TryShoot() {
        if(!_canShoot) return; //pokud je boolean false, tak nemohu střílet. Například pokud uživatel pauznul hru (PausePanelSystem)

        switch (_weaponSwitcher.CurrentWeaponSO.ShootStyle)
        {
            case WeaponShootStyle.PRESS:
                if (_weaponScript != null && Input.GetMouseButton(0)) Shoot();
                break;

            case WeaponShootStyle.ONE_TAP:
                if (_weaponScript != null && Input.GetMouseButtonDown(0)) Shoot();
                break;
        }

    }

    private void Shoot(){
        _weaponScript.PlayShootingAnimation();
    }

    private void UpdateWeapon() {
        _weapon = WeaponSwitcher.Instance.CurrentWeaponObj;
        _weaponScript = _weapon.GetComponent<Weapon>();
    }

    private void ChangeShootState(bool value) {
        _canShoot = value;
    }

}