using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform gunbarrel;
    public Transform NearlTarget=null;
    public static event Action OnDestroyEnemy;

    public int HP = 100;
    public int ATK;

    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    [Header("PS for Destroy")]
    public ParticleSystem Destroy_ParticleSystem;


    private void Awake()
    {
        Destroy_ParticleSystem.Stop();
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();
    }

    public void Initialize()
    {
        
    }
    public void Prefare()
    {

    }
    public void Begin()
    {
        MuzzelFlash_ParticleSystem.Play();
        BulletShells_ParticleSystem.Play();
        Traser_ParticleSystem.Play();
    }
    Transform FindTarget()
    {




        return NearlTarget;
    }
    public void CheckHP(int damage)
    {
        HP = HP - damage;
        if (HP <= 0)
        {
            OnDestroyEnemy?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision bullet)
    {
        //CheckHP(10);
        //Debug.Log("OnCollisionEnter!!!!!" + bullet.gameObject.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        //CheckHP(10);
        //Debug.Log("OnTriggerEnter!!!!!" + other.name);
    }
    private void Update()
    {
        if (NearlTarget == null) return; 

        gunbarrel.LookAt(NearlTarget);
    }


}
