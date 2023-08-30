using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyDependentData", menuName = "ScriptableObjects/DifficultyDependentData", order = 0)]
public class DifficultyDependentData : ScriptableObject
{
    [SerializeField] private GameDifficultySO _gameDifficultySO;
    
    ////////////////////////////////////////////////////////////SPEED////////////////////////////////////////////////////////////////////
    [Header("Easy mode speed variables")]
    [Header("SPEED")]
    //Easy difficulty min and max speed
    [SerializeField] private float _easyMinSpeed;
    [SerializeField] private float _easyMaxSpeed;

    [Header("Medium mode speed variables")]
    [Space(10)]
    //Medium difficulty min and max speed
    [SerializeField] private float _medMinSpeed;
    [SerializeField] private float _medMaxSpeed;

    [Header("Hard mode speed variables")]
    [Space(10)]
    //Hard difficulty min and max speed 
    [SerializeField] private float _hardMinSpeed;
    [SerializeField] private float _hardMaxSpeed;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////DAMAGE////////////////////////////////////////////////////////////////////
    [Header("Easy mode damage variables")]
    [Header("DAMAGE")]
    //Easy difficulty min and max damage
    [SerializeField] private float _easyMinDamage;
    [SerializeField] private float _easyMaxDamage;

    [Header("Medium mode damage variables")]
    [Space(10)]
    //Medium difficulty min and max damage
    [SerializeField] private float _medMinDamage;
    [SerializeField] private float _medMaxDamage;

    [Header("Hard mode damage variables")]
    [Space(10)]
    //Hard difficulty min and max damage 
    [SerializeField] private float _hardMinDamage;
    [SerializeField] private float _hardMaxDamage;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////HEALTH/////////////////////////////////////////////////////////////////////
    [Header("Easy mode health variables")]
    [Header("HEALTH")]
    //Easy difficulty min and max health
    [SerializeField] private float _easyMinHealth;
    [SerializeField] private float _easyMaxHealth;

    [Header("Medium mode health variables")]
    [Space(10)]
    //Medium difficulty min and max health 
    [SerializeField] private float _medMinHealth;
    [SerializeField] private float _medMaxHealth;

    [Header("Hard mode health variables")]
    [Space(10)]
    //Hard difficulty min and max health 
    [SerializeField] private float _hardMinHealth;
    [SerializeField] private float _hardMaxHealth;
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////INTERVAL////////////////////////////////////////////////////////////////////
    [Header("INTERVAL")]
    [Space(10)]
    [SerializeField] private float _easyInterval;
    [SerializeField] private float _medInterval;
    [SerializeField] private float _hardInterval;
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////SONIC WAVE DAMAGE///////////////////////////////////////////////////////////
    [Header("SONIC WAVE DAMAGE")]
    [Space(10)]
    [SerializeField] private float _easySWDamage;
    [SerializeField] private float _medSWDamage;
    [SerializeField] private float _hardSWDamage;
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////SONIC WAVE POWER////////////////////////////////////////////////////////////
    [Header("SONIC WAVE POWER")]
    [Space(10)]
    [SerializeField] private int _easySWPower;
    [SerializeField] private int _medSWPower;
    [SerializeField] private int _hardSWPower;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////SONIC WAVE RADIUS////////////////////////////////////////////////////////////
    [Header("SONIC WAVE RADIUS")]
    [Space(10)]
    [SerializeField] private int _easySWRadius;
    [SerializeField] private int _medSWRadius;
    [SerializeField] private int _hardSWRadius;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

     ////////////////////////////////////////////////////////////SONIC WAVE RADIUS////////////////////////////////////////////////////////////
    [Header("SONIC WAVE UPFORCE")]    
    [Space(10)]
    [SerializeField] private int _easySWUpForce;
    [SerializeField] private int _medSWUpForce;
    [SerializeField] private int _hardSWUpForce;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Zjednodušit metody
    public float GetSpeed() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return Random.Range(_easyMinSpeed, _easyMaxSpeed);

            case Difficulty.MEDIUM:
                return Random.Range(_medMinSpeed, _medMaxSpeed);

            case Difficulty.HARD:
                return Random.Range(_hardMinSpeed, _hardMaxSpeed);
            
            default:
                return 0;
        }
    }

    public float GetDamage() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return Random.Range(_easyMinDamage, _easyMaxDamage);

            case Difficulty.MEDIUM:
                return Random.Range(_medMinDamage, _medMaxDamage);

            case Difficulty.HARD:
                return Random.Range(_hardMinDamage, _hardMaxDamage);
            
            default:
                return 0;
        }
    }

    public float GetHealth() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return Random.Range(_easyMinHealth, _easyMaxHealth);

            case Difficulty.MEDIUM:
                return Random.Range(_medMinHealth, _medMaxHealth);

            case Difficulty.HARD:
                return Random.Range(_hardMinHealth, _hardMaxHealth);
            
            default:
                return 0;
        }
    }

    public float GetInterval() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return _easyInterval;

            case Difficulty.MEDIUM:
                return _medInterval;

            case Difficulty.HARD:
                return _hardInterval;
            
            default:
                return 999;
        }
    }

    public float GetSonicWaveDamage() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return _easySWDamage;

            case Difficulty.MEDIUM:
                return _medSWDamage;

            case Difficulty.HARD:
                return _hardSWDamage;
            
            default:
                return 0;
        }
    }

    public float GetSonicWavePower() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return _easySWPower;

            case Difficulty.MEDIUM:
                return _medSWPower;

            case Difficulty.HARD:
                return _hardSWPower;
            
            default:
                return 0;
        }
    }

    public float GetSonicWaveRadius() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return _easySWRadius;

            case Difficulty.MEDIUM:
                return _medSWRadius;

            case Difficulty.HARD:
                return _hardSWRadius;
            
            default:
                return 0;
        }
    }    
    
    public float GetSonicWaveUpForce() {
        switch (_gameDifficultySO.Difficulty)
        {
            case Difficulty.EASY:
                return _easySWUpForce;

            case Difficulty.MEDIUM:
                return _medSWUpForce;

            case Difficulty.HARD:
                return _hardSWUpForce;
            
            default:
                return 0;
        }
    }
}
