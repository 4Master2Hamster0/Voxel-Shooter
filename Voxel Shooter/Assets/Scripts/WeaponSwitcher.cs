using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooting))]
[RequireComponent(typeof(WeaponSwitcher))]
public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> _weapons = new List<WeaponSO>();
    [SerializeField] private GameObject _currentWeaponObj; 
    [SerializeField] private WeaponSO _currentWeaponSO;
    [SerializeField] private GameObject _player;    //nemá getter, protože tato instance již existuje v ReferenceManager
    [SerializeField] private int _index;            //index asi nebudu potřebovat v jiných skriptech

    public List<WeaponSO> Weapons => _weapons;
    public GameObject CurrentWeaponObj => _currentWeaponObj;
    public WeaponSO CurrentWeaponSO => _currentWeaponSO;

    public static WeaponSwitcher Instance {get; private set;}

    private void Awake() {
        Instance = this;
        _currentWeaponObj = transform.GetChild(0).gameObject; //CurrentWeaponObj musím inicializovat co nejdřív, abych nedostával null reference exception 
        _currentWeaponSO = _weapons[0];
    }

    private void Start() {
        Init();
        SwitchWeapon(0); // aby na začátku hry hráči byla přidělena zbraň
    }

    private void Update() {
        //kolečkem listuju zbraněmi vzestupně
        if(Input.mouseScrollDelta.y > 0 && _index != _weapons.Count-1)  
        {
            
            SwitchWeapon(++_index); //TODO: metodu vložit do OnWeaponSwitch eventu (možná udělat dvě metody, do ních dát index++ a switch weapon a každou z nich použít v ifu a else ifu. Například ScrollDown, ScrollUp)
        }
        //kolečkem listuju zbraněmi sestupně
        else if(Input.mouseScrollDelta.y < 0 && _index != 0) 
        {
            SwitchWeapon(--_index);
        }
    }

    private void Init() {
        _index = 0;
        _player = ReferenceManager.Instance.Player;
       
    }

    private void SwitchWeapon(int index)
    {
        if(_currentWeaponObj != null) Destroy(_currentWeaponObj);
        _currentWeaponSO = _weapons[index];

        GameObject zbranInstance = Instantiate(_currentWeaponSO.WeaponPrefab, Vector3.zero, Quaternion.identity, transform);

        _currentWeaponObj = zbranInstance;
        WeaponEvent.OnWeaponSwitch?.Invoke();
    }

}
 