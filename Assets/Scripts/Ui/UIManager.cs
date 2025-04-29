using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public  event Action OnGameEndEvent;
    public  event Action OnGameAgainEvent;
    
    public GameObject _panelWinLose;
    public GameObject _panelMain;

    public Button _StarBtn;

    public TextMeshProUGUI _TurretAmount;  // UI에텍스트 필드.   
    public TextMeshProUGUI _EnemyAmount;  // UI에 텍스트 필드.
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
        _StarBtn.gameObject.SetActive(false);
        _panelWinLose.gameObject.SetActive(false);
    }

    public void ShowWinLosePanel(string winner)
    {
        _winnerIs.text = winner;
        _panelWinLose.gameObject.SetActive(true);
    }
    public void ShowStartBtn(bool boo)
    {
        _StarBtn.gameObject.SetActive(boo);
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
