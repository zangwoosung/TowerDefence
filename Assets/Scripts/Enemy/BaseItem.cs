using TMPro;
using UnityEngine;

public class BaseItem :MonoBehaviour
{
     public TextMeshProUGUI ATKtxt;
     public Transform gunbarrel;
     public TextMeshProUGUI HPtxt;

    [Header("PS")]
     public ParticleSystem MuzzelFlash_ParticleSystem;
     public ParticleSystem BulletShells_ParticleSystem;
     public ParticleSystem Traser_ParticleSystem;

    [SerializeField] public    Transform NearTarget = null;
    [SerializeField] public    string targetTag;

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
    private void Start()
    {
      //  Begin();

    }
    public void Initialize()
    {

    }
    public void Prefare(GameObject[] targets)
    {
        //NearTarget = NearestTarget.FindNearestTarget(gameObject, targets).transform;
    }
    public void Begin()
    {       
        OpenFire();
    }
    void OpenFire()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        if (targets.Length == 0) return;


        NearTarget = NearestTarget.FindNearestTarget(gameObject, targets).transform;

        if (NearTarget==null) return;

        MuzzelFlash_ParticleSystem.Play();

        BulletShells_ParticleSystem.Play();
        Traser_ParticleSystem.Play();
        Invoke("CeaseFire", 5);
    }
   public void CeaseFire()
    {
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();
        Invoke("OpenFire", 3);

    }

    private void Update()
    {
        if (NearTarget == null) return;
        gunbarrel.LookAt(NearTarget);
    }
    
    public  virtual void CheckHP(int damage)
    {
        
    }
    public virtual void Explode()
    {

        gameObject.SetActive(false);
        Destroy(gameObject);
        
    }

}
