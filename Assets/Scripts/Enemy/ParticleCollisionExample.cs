using UnityEngine;

public class ParticleCollisionExample : MonoBehaviour
{
    public ParticleSystem particleSystem; 

    void Start()
    {
        var collision = particleSystem.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        //collision.collidesWith = LayerMask.GetMask("Default");
    }

    void OnParticleCollision(GameObject other)
    {
        

        // 적이 피격되었나를 어떻게 판단할까? 
        // 적이 피격 혹은 옆에 있는 건물이 피격 될 수도 있으니까.
        // 
        if (other.GetComponent<Enemy>() != null)
        {
            Debug.Log("Enemy hit");
            other.GetComponent<Enemy>().CheckHP(1);
        }

        if (other.GetComponent<Turret>())
        {
            Debug.Log("Turret hit");
            other.GetComponent<Turret>().TakeDamage(1);
        }
    }
}