using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

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
        Turret.StaticDestroyEvent += Turret_StaticDestroyEvent;
        Enemy.OnDestroyEnemy += Enemy_OnDestroyEnemy;
        mainUI.OnGameEndEvent += UIManager_OnGameEndEvent;
        mainUI.OnGameAgainEvent += UIManager_OnGameAgainEvent;


        TotalEnemy = 5;
        TotalTurret = 5;
        mainUI.TotalEnemy = TotalEnemy;
        mainUI.TotalTurret = TotalTurret;
        StartCoroutine(Initialize());
        //Prefare();
    }

    private void Enemy_OnDestroyEnemy()
    {
        TotalEnemy--;
        mainUI.TotalEnemy = TotalEnemy;
        if (TotalEnemy <= 0)
        {
            mainUI.ShowWinLosePanel("Turret");

        }
    }

    private void Turret_StaticDestroyEvent()
    {
        TotalTurret--;
        mainUI.TotalTurret = TotalTurret;
        if (TotalTurret <= 0)
        {
            mainUI.ShowWinLosePanel("Enemy");

        }
    }

    private void UIManager_OnGameAgainEvent()
    {
        ClearBattleField();

        TotalEnemy = 5;
        TotalTurret = 5;
        mainUI.TotalEnemy = TotalEnemy;
        mainUI.TotalTurret = TotalTurret;
        StartCoroutine(Initialize());
        Prefare();
    }

    void ClearBattleField()
    {
        int numChildren = battleField.transform.childCount;
        for (int i = numChildren - 1; i > 0; i--)
            GameObject.Destroy(battleField.transform.GetChild(i).gameObject);

    }

    void CeaseFire()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in targets)
        {
            enemy.GetComponent<Enemy>().CeaseFire();
        }

        targets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject obj in targets)
        {
            obj.GetComponent<Turret>().CeaseFire();
        }
    }


    private void UIManager_OnGameEndEvent()
    {
        CeaseFire();
        ClearBattleField();
    }

    IEnumerator Initialize()
    {
        for (int i = 0; i < 5; i++)
        {
            int xPos = Random.Range(-20, 20);
            int zPos = Random.Range(-20, 20);
            Vector3 pos = new Vector3(xPos, 0, zPos);
            GameObject obj = Instantiate(enemyPrefab, pos, Quaternion.identity);

            obj.transform.position = pos;
            obj.transform.SetParent(battleField.transform);
            enemyObj[i] = obj;
            //obj.GetComponent<Enemy>().enabled=false;
            enemies[i] = obj.GetComponent<Enemy>();

            obj.GetComponent<SplineAnimate>().StartOffset = Random.Range(0, 1);
            yield return new WaitForSeconds(0.5f);
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
    }
    void Prefare()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].HP = Random.Range(10000, 15000);
            enemies[i].ATK = Random.Range(100, 150);
            enemies[i].Prefare(turretObj);
            enemies[i].HodeFire();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            turrets[i].HP = Random.Range(10000, 15000);
            turrets[i].ATK = Random.Range(100, 150);
            turrets[i].Prefare(enemyObj);
            turrets[i].HodeFire();
        }
    }

    public void StartGame()
    {
        
    }



}
