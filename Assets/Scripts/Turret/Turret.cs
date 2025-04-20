using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TextMeshProUGUI HPtxt;
    public TextMeshProUGUI ATKtxt;

    public static event Action StaticDestroyEvent;
    public        event Action NotStaticDestroyEvent;
    
    public Transform gunbarrel;
    public Transform NearTarget;
    
    
    
    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    [Header("PS Destroy")]
    public ParticleSystem Destroy_ParticleSystem;

    private int hp;

    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;

            HPtxt.text = hp.ToString();
        }
    }

    private int atk;

    public int ATK
    {
        get { return atk; }
        set
        {
            atk = value;

            ATKtxt.text = atk.ToString();
        }
    }

    int BulletCount = 5;
    float lapTime = 0;
   
    private void Awake()
    {
        Destroy_ParticleSystem.Stop();
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();
    }
    public void Initialize()
    {      
        Invoke("DoSomething", 3);
    }
    public void Begin()
    {
        DoSomething();
    }
    public void Prefare(GameObject[] targets)
    {
        NearTarget = NearestTarget.FindNearestTarget(gameObject, targets).transform;
    }
    public  void FindNewTarget()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> targets = new List<GameObject>();

        int enemyLayer = LayerMask.NameToLayer("Enemy");

        foreach (GameObject obj in allObjects)
        {
            if (obj.tag == "Enemy")
            {
                targets.Add(obj);
            }
        }
        if (targets.Count == 0) return;
        Prefare(targets.ToArray());
        LoatAtTarget();
    }
    public void LoatAtTarget()
    {
        gunbarrel.LookAt(NearTarget);
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
        lapTime += Time.deltaTime;  // 1�ʿ� 24����, 0.22

        if(lapTime > 1)
        { 
            Fire();
            lapTime = 0;
        }


        if (NearTarget == null)
        {
            FindNewTarget();
        }
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
        StaticDestroyEvent?.Invoke();
        transform.gameObject.SetActive(false);   // �����.         
        Destroy(gameObject);
    }
   public void CeaseFire()
    {
       // Destroy_ParticleSystem.Stop();
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();
    }
    public void TakeDamage(int damage)
    {
        HP = HP - damage;

        if (HP <= 0)        
            Destroy();
        
    }
}
