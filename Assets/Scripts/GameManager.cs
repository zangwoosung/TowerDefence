using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject turretPrefab;
    public Transform  world;

    
    public Enemy enemy;
    public Turret turret;
   

    // Initialize  : Player and enemy 생성
    // Prefare     :  설정 , UI 표시
    // Begin game  : 사용자의 입력 




    void Start()
    {

       
        Initialize();


        enemy.HP = UnityEngine.Random.Range(100, 150);
        turret.HP = UnityEngine.Random.Range(100, 150);

        enemy.ATK = UnityEngine.Random.Range(100, 150);
        turret.ATK = UnityEngine.Random.Range(100, 150);

    }
    void Initialize()
    {
        for (int i = 0; i < 5; i++)
        {
            int xPos = UnityEngine.Random.Range(2, 10);
            int zPos = UnityEngine.Random.Range(2, 10);


            Vector3 pos = new Vector3(xPos, 0, zPos);
            Instantiate(enemyPrefab, pos, Quaternion.identity).transform.SetParent(world);
        }
    }
    void Prefare()
    {
        enemy.HP = UnityEngine.Random.Range(100, 150);
        turret.HP = UnityEngine.Random.Range(100, 150);

        enemy.ATK = UnityEngine.Random.Range(100, 150);
        turret.ATK = UnityEngine.Random.Range(100, 150);
    }

    void BeginGame()
    {

    }




}
