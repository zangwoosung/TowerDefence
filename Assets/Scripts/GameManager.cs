using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject turretPrefab;
    public GameObject battleField;
   
    public GameObject[] turretObj = new GameObject[5];
    public GameObject[] enemyObj = new GameObject[5];

    Enemy[] enemies = new Enemy[5];
    Turret[] turrets = new Turret[5];



    void Start()
    {
        Initialize();
        //Prefare();     


    }
    void Initialize()
    {
        for (int i = 0; i < 5; i++)
        {
            int xPos = UnityEngine.Random.Range(-20, 20);
            int zPos = UnityEngine.Random.Range(-20, 20);
            Vector3 pos = new Vector3(xPos, 0, zPos);
            GameObject obj = Instantiate(enemyPrefab, pos, Quaternion.identity);

            obj.transform.position = pos;
            obj.transform.SetParent(battleField.transform);
            enemyObj[i] = obj;
            enemies[i] = obj.GetComponent<Enemy>();
        }
        for (int i = 0; i < 5; i++)
        {
            int xPos = UnityEngine.Random.Range(-20, 20);
            int zPos = UnityEngine.Random.Range(-20, 20);
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
            enemies[i].HP = UnityEngine.Random.Range(100, 150);
            enemies[i].ATK = UnityEngine.Random.Range(100, 150);
            enemies[i].Prefare(turretObj);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            turrets[i].HP = UnityEngine.Random.Range(100, 150);
            turrets[i].ATK = UnityEngine.Random.Range(100, 150);
            turrets[i].Prefare(enemyObj);
        }
    }

    void BeginGame()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Begin();
            turrets[i].Begin();
            //enemies[i].ATK = UnityEngine.Random.Range(100, 150);

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
