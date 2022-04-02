using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _targetDirection;
    private bool _isTrigger;
    public float enemySpeed;
    
    private PlayerController _playerController;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        _targetDirection = Vector2.zero;
    }

    
    private void Update()
    {
        if (_isTrigger)
        {
            _targetDirection = _playerController.transform.position - transform.position;       // Cria um vetor apontado para a posição do jogador
        }
        else
        {
            _targetDirection = Vector2.zero;
        }

        _rigidbody2D.velocity = _targetDirection.normalized * enemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isTrigger = false;
        }
    }
}