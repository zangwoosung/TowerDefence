using UnityEngine;

public class ParticleCollisionExample : MonoBehaviour
{
    public ParticleSystem myps; 
    public LayerMask mask;

    [SerializeField] BaseItem baseItem;

    void Start()
    {
        var collision = myps.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        collision.collidesWith = mask;// LayerMask.GetMask(mask);
    }

    void OnParticleCollision(GameObject other)
    {   
        if (other.GetComponent<BaseItem>())
        {
            Debug.Log("Enemy hit");
            other.GetComponent<BaseItem>().CheckHP(baseItem.ATK);
        }

    }
}