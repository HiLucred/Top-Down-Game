using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    private Rigidbody2D _rigidbody2D;
    
    private Camera _camera;

    private GunController _gunController;
    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gunController = FindObjectOfType<GunController>();
    }

    private void Start()
    {
        transform.rotation = _gunController.transform.rotation;     // Seta a rotação da bala igual a da arma //
        BulletMovement();
        DestroyBall();
    }
    
    private void BulletMovement()
    {
        var targetCamera = _camera.ScreenToWorldPoint(Input.mousePosition);     // Posição do mouse
        var vecShoot = (targetCamera - transform.position).normalized;          // Cria um vetor apontado para a posição do mouse
        
        _rigidbody2D.AddForce(vecShoot * ballSpeed);                        // Adiciona uma força na direção deste vetor criado na linha acima
    }

    private void DestroyBall()
    {
        Destroy(gameObject, 3f);
    }
}