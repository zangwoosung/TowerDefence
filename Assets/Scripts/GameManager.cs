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

    Enemy[] enemies = new Enemy[5];
    Turret[] turrets = new Turret[5];

    public GameObject  splineForEnemyObj;
    public SplineContainer         splineForEnem;

    void Start()
    {
        UIManager.OnGameEndEvent += UIManager_OnGameEndEvent;
        UIManager.OnGameAgainEvent += UIManager_OnGameAgainEvent;
        Initialize();
    }

    private void UIManager_OnGameAgainEvent()
    {
        ClearBattleField();
        Initialize();
    }

    void ClearBattleField()
    {
        int numChildren = battleField.transform.childCount;
        for (int i = numChildren - 1; i > 0; i--)
        {
            GameObject.Destroy(battleField.transform.GetChild(i).gameObject);
        }
       
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

    void Initialize()
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
           
             enemies[i] = obj.GetComponent<Enemy>();
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
            enemies[i].HP = Random.Range(100, 150);
            enemies[i].ATK = Random.Range(100, 150);
            enemies[i].Prefare(turretObj);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            turrets[i].HP = Random.Range(100, 150);
            turrets[i].ATK = Random.Range(100, 150);
            turrets[i].Prefare(enemyObj);
        }
    }

    void BeginGame()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Begin();
            turrets[i].Begin();    

        }
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Prefare();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BeginGame();
        }
       
    }

    

    

}
