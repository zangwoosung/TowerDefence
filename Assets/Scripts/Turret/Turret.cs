using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BastItem : MonoBehaviour
{
    public TextMeshProUGUI HPtxt;
    public TextMeshProUGUI ATKtxt;
    public Transform gunbarrel;
    public Transform NearTarget;



    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    [Header("PS Destroy")]
    public ParticleSystem Destroy_ParticleSystem;

    public string TargetTag;

    [field: SerializeField]
    public string MyTag { get; set; }


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
    public void FindNewTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(MyTag);
        
        if (targets.Length == 0) return;
        Prefare(targets);
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
        lapTime += Time.deltaTime;  // 1초에 24실행, 0.22

        if (lapTime > 1)
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

    public virtual void Destroy()
    {
      
        transform.gameObject.SetActive(false);   // 사라짐.         
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
public class Turret : BastItem
{
    public static event Action StaticDestroyEvent;

    public override  void Destroy()
    {
        StaticDestroyEvent?.Invoke();
        base.Destroy();
        
    }
}
