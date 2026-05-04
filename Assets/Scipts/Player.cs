using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    
    private InputAction _moveAction;
    private InputAction _jumpAction;

    private Rigidbody _rg;
    private bool CanJump => _rg.linearVelocity.y == 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _moveAction.Enable();
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var moveForce = _moveAction.ReadValue<Vector2>().x;
        var newVelocity = moveForce * movementSpeed;
        _rg.linearVelocity = new Vector3(newVelocity, _rg.linearVelocity.y, _rg.linearVelocity.z);

        if (_jumpAction.WasPressedThisFrame() && CanJump)
        {
            _rg.AddForce(Vector3.up * jumpForce);
        }
    }
}
