using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public  event Action OnGameEndEvent;
    public  event Action OnGameAgainEvent;
    public TextMeshProUGUI _TurretAmount;  // UI에텍스트 필드.   
    public TextMeshProUGUI _EnemyAmount;  // UI에 텍스트 필드.
    public GameObject _panelMain;
    public GameObject _panelWinLose;
    public TextMeshProUGUI _winnerIs;          

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
    }

    public void ShowWinLosePanel(string winner)
    {
        _winnerIs.text = winner;
        _panelWinLose.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Again()
    {       
        _panelWinLose.gameObject.SetActive(false);
        OnGameAgainEvent?.Invoke();
    }

}
