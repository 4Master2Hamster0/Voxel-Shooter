using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance { get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _weaponSlot;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private WeaponSwitcher _weaponSwitcher;
    [SerializeField] private GameObject _rayCastPoint;
    [SerializeField] private WeaponSO _ak;
    [SerializeField] private WeaponSO _pistole;
    [SerializeField] private BulletSO _bullet;
    [SerializeField] private GameDifficultySO _gameDifficultySO;
    [SerializeField] private DifficultyDependentData _difficultyDependentData;
    [SerializeField] private PlayerStatsSO _playerStatsSO;
    

    public GameObject Player => _player;
    public GameObject WeaponSlot => _weaponSlot;
    public GameObject PausePanel => _pausePanel;
    public WeaponSwitcher WeaponSwitcher => _weaponSwitcher;
    public GameObject RayCastPoint => _rayCastPoint;
    public WeaponSO Ak => _ak;
    public WeaponSO Pistole => _pistole;
    public BulletSO BulletSO => _bullet;
    public GameDifficultySO GameDifficultySO => _gameDifficultySO;
    public DifficultyDependentData DifficultyDependentData => _difficultyDependentData;
    public PlayerStatsSO PlayerStatsSO => _playerStatsSO;

    private void Awake() {
        if(Instance == null) Instance = this;
    }

}
