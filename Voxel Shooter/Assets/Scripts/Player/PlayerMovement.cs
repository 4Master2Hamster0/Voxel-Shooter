using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _sensitivity;
    [SerializeField] private PlayerStatsSO _playerStatsSO;
    private Rigidbody _rB;
    private Vector3 _directionVec;
    private Camera _cam;
    private GameObject _player;
    private float _mouseX, _mouseY, _keybX, _keybY, _camRotation;

    public PlayerStatsSO playerStatsSO => _playerStatsSO;

    void Start() 
    {
        _rB = GetComponent<Rigidbody>();
        _cam = Camera.main;
        _player = gameObject;
        _camRotation = 0;

        _speed = _playerStatsSO.Speed;
        _jumpForce = _playerStatsSO.JumpForce;
        _sensitivity = _playerStatsSO.Sensitivity;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() 
    {
        _keybX = Input.GetAxis("Horizontal");
        _keybY = Input.GetAxis("Vertical");

        _mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _sensitivity;
        _mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _sensitivity;

        _directionVec = new Vector3(_keybX, 0, _keybY);

        if(Input.GetKey(KeyCode.Space) && isGrounded()) {
            _rB.AddForce(transform.up * _jumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        LookAround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public bool isGrounded()
    {
        BoxCollider collider = GetComponent<BoxCollider>();

        if(Physics.Raycast(collider.bounds.center, Vector3.down, (collider.bounds.size.y/2) + 0.1f)){
            return true;
        }
        else return false;
    }

    public void Move()
    {
        transform.Translate(_directionVec * Time.deltaTime * _speed, Space.Self);
    }

    public void LookAround()
    { 
        _camRotation -= _mouseY;
        _camRotation = Mathf.Clamp(_camRotation, -75f, 75f);
        _cam.transform.localEulerAngles = Vector3.right * _camRotation;

        transform.Rotate(Vector3.up * _mouseX);
    }
}