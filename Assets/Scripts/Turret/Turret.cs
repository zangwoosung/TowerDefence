using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public static event Action StaticDestroyEvent;
    public        event Action NotStaticDestroyEvent;
    
    public Transform gunbarrel;
    public Transform RealTarget;
    public GatlingGun gatlingGun;
    
    public UIManager _UIManager;
    
    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    [Header("PS Destroy")]
    public ParticleSystem Destroy_ParticleSystem;     

   
    public int HP;      // 생존력,  HP
    public int ATK;  
    int BulletCount = 5;
    float lapTime = 0;

    private void Start()
    {
        Destroy_ParticleSystem.Stop();  
        gatlingGun.enabled = false;
        Invoke("DoSomething", 3);
    }

    void DoSomething()
    {
        MuzzelFlash_ParticleSystem.Play();
        BulletShells_ParticleSystem.Play();
        Traser_ParticleSystem.Play();
    }
    public void Fire()
    {
        if (BulletCount <= 0)
        {
            Reload();
            return;
        }
        BulletCount--;
    }
      
    private void Update()
    {
        lapTime += Time.deltaTime;  // 1초에 24실행, 0.22

        if(lapTime > 1)
        { 
            Fire();
            lapTime = 0;
        }
        gunbarrel.LookAt(RealTarget);
    }

    public void Reload()
    {
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();

        BulletCount = 5;
        Invoke("DoSomething", 3);
    }

    void Destroy()
    {  
        transform.gameObject.SetActive(false);   // 사라짐.         
        Destroy_ParticleSystem.Play();   
       
    }

    public void TakeDamage(int damage)
    {
        HP = HP - damage;

        if (HP <= 0)        
            Destroy();
        
    }
}
