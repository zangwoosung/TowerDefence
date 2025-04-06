using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy enemy;

    public Turret turret;
   


    void Start()
    {
        enemy.HP = UnityEngine.Random.Range(100, 150);
        turret.HP = UnityEngine.Random.Range(100, 150);

        enemy.ATK = UnityEngine.Random.Range(100, 150);
        turret.ATK = UnityEngine.Random.Range(100, 150);

    }

   
}
