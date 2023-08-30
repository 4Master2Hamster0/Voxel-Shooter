using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    private void Start() {
        _player = ReferenceManager.Instance.Player;
        _speed = ReferenceManager.Instance.DifficultyDependentData.GetSpeed();
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(_player.transform.position - transform.position, transform.up);
    }
}
