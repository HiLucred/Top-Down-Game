using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _vecMovement;
    private Vector2 _camPosition;
    
    public new Camera camera;

    public float speedMovement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _camPosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        MovementInput();
        MovementRotate();
    }

    private void MovementInput()
    {
        var movX = Input.GetAxisRaw("Horizontal");
        var movY = Input.GetAxisRaw("Vertical");

        _vecMovement = new Vector2(movX, movY).normalized;
        
        _rigidbody2D.velocity = _vecMovement * speedMovement;
    }

    private void MovementRotate()
    {
        var lookDirection = _camPosition - _rigidbody2D.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;

        _rigidbody2D.rotation = angle;
    }
}