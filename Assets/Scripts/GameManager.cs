using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public GameObject turretPrefab;
    public GameObject battleField;

    public GameObject[] turretObj = new GameObject[5];
    public GameObject[] enemyObj = new GameObject[5];
    [SerializeField] UIManager mainUI;
    Enemy[] enemies = new Enemy[5];
    Turret[] turrets = new Turret[5];


    


    int TotalEnemy;
    int TotalTurret;
    void Start()
    {
        BaseItem.OnGameOverEvent += BaseItem_OnGameOverEvent;
        Turret.StaticDestroyEvent += Turret_StaticDestroyEvent;
        Enemy.OnDestroyEnemy += Enemy_OnDestroyEnemy;
        mainUI.OnGameEndEvent += UIManager_OnGameEndEvent;
        mainUI.OnGameAgainEvent += UIManager_OnGameAgainEvent;


        TotalEnemy = 5;
        TotalTurret = 5;
        mainUI.TotalEnemy = TotalEnemy;
        mainUI.TotalTurret = TotalTurret;        
        StartCoroutine(Initialize());
        
    }

    private void BaseItem_OnGameOverEvent(ItemType obj)
    {
        //CeaseFire();
        //switch (obj)
        //{
        //    case ItemType.Enemy:
        //        mainUI.ShowWinLosePanel(ItemType.Turret.ToString());
        //        break;
        //    case ItemType.Turret:
        //        mainUI.ShowWinLosePanel(ItemType.Enemy.ToString());
        //        break;
        //    default:
        //        break;
        //}
       
    }

    private void Enemy_OnDestroyEnemy()
    {
        TotalEnemy--;
        mainUI.TotalEnemy = TotalEnemy;
        
    }

    private void Turret_StaticDestroyEvent()
    {
        TotalTurret--;
        mainUI.TotalTurret = TotalTurret;        
    }

    private void UIManager_OnGameAgainEvent()
    {
        ClearBattleField();
        
        StartCoroutine(Initialize());
     
    }

    void ClearBattleField()
    {
        int numChildren = battleField.transform.childCount;
        for (int i = numChildren - 1; i > 0; i--)
            GameObject.Destroy(battleField.transform.GetChild(i).gameObject);

    }

    void CeaseFire()
    {
        int numChildren = battleField.transform.childCount;
        for (int i = numChildren - 1; i > 0; i--)
        {
            GameObject obj = battleField.transform.GetChild(i).gameObject;
            if(obj.GetComponent<BaseItem>() != null)
            {
                obj.GetComponent<BaseItem>().CeaseFire();
                
            }
            
        }


    }


    private void UIManager_OnGameEndEvent()
    {
        CeaseFire();
        ClearBattleField();
    }

    IEnumerator Initialize()
    {
        TotalEnemy = 5;
        TotalTurret = 5;
        mainUI.TotalEnemy = TotalEnemy;
        mainUI.TotalTurret = TotalTurret;

        for (int i = 0; i < 5; i++)
        {
            int xPos = Random.Range(-20, 20);
            int zPos = Random.Range(-20, 20);
            Vector3 pos = new Vector3(xPos, 0, zPos);
            GameObject obj = Instantiate(enemyPrefab, pos, Quaternion.identity);

            obj.transform.position = pos;
            obj.transform.SetParent(battleField.transform);
            enemyObj[i] = obj;            
            enemies[i] = obj.GetComponent<Enemy>();

            obj.GetComponent<SplineAnimate>().StartOffset = Random.Range(0.0f, 1.0f);
            yield return new WaitForSeconds(1.5f);
        }
        for (int i = 0; i < 5; i++)
        {
            int xPos = Random.Range(-20, 20);
            int zPos = Random.Range(-20, 20);
            Vector3 pos = new Vector3(xPos, 0, zPos);
            GameObject obj = Instantiate(turretPrefab, pos, Quaternion.identity);

            obj.transform.position = pos;
            obj.transform.SetParent(battleField.transform);
            turretObj[i] = obj;
            turrets[i] = obj.GetComponent<Turret>();
        }
        Prefare();
    }
    void Prefare()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].HP = Random.Range(1000, 1500);
            enemies[i].ATK = Random.Range(100, 150);         
            
            turrets[i].HP = Random.Range(10000, 15000);
            turrets[i].ATK = Random.Range(100, 150);                    
        }

        mainUI.ShowStartBtn(true);
    }

    public void StartGame()
    {
        for (int i = 0; i < enemies.Length; i++)
        {            
            turrets[i].Begin();
            enemies[i].Begin();
        }
    }
}
