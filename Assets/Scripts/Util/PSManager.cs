﻿using UnityEngine;

public class PSManager : MonoBehaviour
{

    [SerializeField] ParticleSystem _particlesEnemy;
    [SerializeField] ParticleSystem _particlesTurret;


    private void Awake()
    {
        _particlesEnemy.gameObject.SetActive(false);
        _particlesTurret.gameObject.SetActive(false);
        
    }
    private void Start()
    {
        Enemy.OnDestroyEnemyPos += Enemy_OnDestroyEnemyPos;
        Turret.StaticDestroyEventPos += Turret_StaticDestroyEventPos;
    }

    private void Turret_StaticDestroyEventPos(Vector3 pos)
    {
        _particlesTurret.gameObject.SetActive(true);
        _particlesTurret.transform.position = pos;
        _particlesTurret.Play();
    }

    private void Enemy_OnDestroyEnemyPos(Vector3 pos)
    {
        _particlesEnemy.gameObject.SetActive(true);
        _particlesEnemy.transform.position = pos;
        _particlesEnemy.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Turret_StaticDestroyEventPos(new Vector3(0, 0, 0));
        }

    }
}
