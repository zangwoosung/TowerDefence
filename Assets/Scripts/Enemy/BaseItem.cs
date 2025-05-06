using System;
using TMPro;
using UnityEngine;

public enum ItemType
{
    Enemy,
    Turret

}
public class BaseItem : MonoBehaviour
{

    public static event Action<ItemType> OnGameOverEvent;
    public TextMeshProUGUI ATKtxt;
    public TextMeshProUGUI HPtxt;
    public Transform gunbarrel;

    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    Transform NearTarget = null;

    [SerializeField] ItemType targetType;

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

    private void Awake()
    {
        CeaseFire();
    }
   

    public void Begin()
    {
        MuzzelFlash_ParticleSystem.gameObject.SetActive(true);
        BulletShells_ParticleSystem.gameObject.SetActive(true);
        Traser_ParticleSystem.gameObject.SetActive(true);

        OpenFire();
    }
    
    void OpenFire()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetType.ToString());
        if (targets.Length == 0)
        {           
            NearTarget = null;
            return;
        }

        NearTarget = NearestTarget.FindNearestTarget(gameObject, targets).transform;
        gunbarrel.LookAt(NearTarget);


        MuzzelFlash_ParticleSystem.Play();
        BulletShells_ParticleSystem.Play();
        Traser_ParticleSystem.Play();
        Invoke("CeaseFire", 5);
    }
    public void CeaseFire()
    {
        Traser_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        MuzzelFlash_ParticleSystem.Stop();
        Invoke("OpenFire", 3);

    }
    public void HodeFire()
    {
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();
    }

    private void Update()
    {
        if (NearTarget == null)
        {
            return;
        }
        gunbarrel.LookAt(NearTarget);
    }

    public virtual void CheckHP(int damage)
    {
        //BaseItem.OnGameOverEvent?.Invoke(ItemType.Turret);


    }
    public virtual void Explode()
    {

        gameObject.SetActive(false);
        Destroy(gameObject);

    }

}
