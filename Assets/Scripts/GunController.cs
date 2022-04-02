using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject ballObject;
    public Transform ballPoint;

    public float timeToShoot;

    private bool _canShoot;
    private float _time;

    private void Start()
    {
        _time = 4f;     // Script começa com o jogador já podendo atirar
    }

    private void Update()
    {
        ShootBullet();
    }
    
    private void ShootBullet()
    {
        _time += Time.deltaTime;
        if (_time >= 4f)        // Caso esteja liberado para atirar e o jogador não atire, o contador para de contar no 4
        {
            _time = 4f;
        }
        
        _canShoot = _time >= timeToShoot;       // O valor de "_canShoot" irá ser setado conforme o resultado da condição proposta (Bool ou False)
    
        if (_canShoot)
        {
            if (!Input.GetMouseButtonDown(0)) return;       // Se não clicar com o mouse, ignora as linhas abaixo
            
            Instantiate(ballObject, ballPoint.position, quaternion.identity);
            _time = 0;
        }
    }
}