using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 0)]
public class PlayerStatsSO : ScriptableObject {

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    

}
