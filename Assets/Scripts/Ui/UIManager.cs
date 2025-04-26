using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static event Action OnGameEndEvent;
    public static event Action OnGameAgainEvent;
    public TextMeshProUGUI _TurretAmount;  // UI에텍스트 필드.   
    public TextMeshProUGUI _EnemyAmount;  // UI에 텍스트 필드.
    public GameObject _panelMain;
    public GameObject _panelWinLose;
    public TextMeshProUGUI _winnerIs;
            //최초 터렛 갯수. 
   // public int TotalEnemy = 5;              //최초 터렛 갯수. 

    private int totalTurret;

    public int TotalTurret
    {
        get { return totalTurret; }
        set { totalTurret = value;

            _TurretAmount.text = TotalTurret.ToString();
        }
    }
    private int totalEnemy;

    public int TotalEnemy
    {
        get { return totalEnemy; }
        set { totalEnemy = value;

            _EnemyAmount.text = TotalEnemy.ToString();
            
        }
    }



    void Start()
    {
        _panelWinLose.gameObject.SetActive(false);
       

        _EnemyAmount.text = TotalEnemy.ToString();
        _TurretAmount.text = TotalTurret.ToString();
    }

    

    public void Quit()
    {
        Application.Quit();
    }
    public void Again()
    {
        TotalEnemy = 5;
        TotalTurret = 5;
        _EnemyAmount.text = TotalEnemy.ToString();
        _TurretAmount.text = TotalTurret.ToString();
        _panelWinLose.gameObject.SetActive(false);
        OnGameAgainEvent?.Invoke();


    }

}
