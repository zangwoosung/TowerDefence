using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEditor.Experimental.GraphView;
using UnityEngine;




public class Wall : MonoBehaviour
{
    //¹æ¹ý 1.
    //public EffectManager effectManager;

    public event Action<Vector3> hitPointEvent;

    void OnParticleCollision(GameObject other)
    {

        Debug.Log("OnParticleCollision ");
        //int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //int i = 0;

        //while (i < numCollisionEvents)
        //{
        //    if (rb)
        //    {
        //        Vector3 pos = collisionEvents[i].intersection;
        //        Vector3 force = collisionEvents[i].velocity * 10;
        //        rb.AddForce(force);
        //    }
        //    i++;
        //}
    }
    private void OnParticleTrigger()
    {
        Debug.Log("OnParticleTrigger");
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        //effectManager.ShowEffect(collision.transform.position);
       // hitPointEvent?.Invoke(collision.transform.position);
        Debug.Log("OnCollisionEnter");
    }
    private void OnTriggerEnter(Collider other)
    {
       //effectManager.ShowEffect(other.transform.position);
       // hitPointEvent?.Invoke(other.transform.position);
       Debug.Log("OnTriggerEnter");
    }

}
