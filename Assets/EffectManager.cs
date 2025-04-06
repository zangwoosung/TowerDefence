using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject _player01; 
    private          GameObject player02; 
    public           GameObject player03; 

    public ParticleSystem bulletHit;

    


    public void ShowEffect(UnityEngine.Vector3 position)
    {
        ParticleSystem ps = GameObject.Find("Simple").GetComponent<ParticleSystem>();
        ps.Play();



        //bulletHit.transform.position = position;
        //bulletHit.gameObject.SetActive(true);
    }

    void Start()
    {
        bulletHit.gameObject.SetActive(false);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //bulletHit.gameObject.SetActive(true);
            ParticleSystem ps = GameObject.Find("Simple").GetComponent<ParticleSystem>();
            ps.Play();
            
        }
    }
}
