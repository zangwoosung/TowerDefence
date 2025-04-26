using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Turret : BaseItem
{
    public static event Action StaticDestroyEvent;
    public static event Action<Vector3> StaticDestroyEventPos;

    public override  void CheckHP(int damage)
    {
        HP = HP - damage;
        if (HP <= 0)
        {
            StaticDestroyEvent?.Invoke();
            StaticDestroyEventPos?.Invoke(transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
}
