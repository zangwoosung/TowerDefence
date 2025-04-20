using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static event Action OnGameEndEvent;
    public static event Action OnGameAgainEvent;
    public TextMeshProUGUI _TurretAmount;  // UI���ؽ�Ʈ �ʵ�.   
    public TextMeshProUGUI _EnemyAmount;  // UI�� �ؽ�Ʈ �ʵ�.
    public GameObject _panelMain;
    public GameObject _panelWinLose; 
    public TextMeshProUGUI _winnerIs;
    public int TotalTurret=5;              //���� �ͷ� ����. 
    public int TotalEnemy=5;              //���� �ͷ� ����. 


   
    void Start()
    {
        _panelWinLose.gameObject.SetActive(false);
        Turret.StaticDestroyEvent += OneTurretRemove;
        Enemy.OnDestroyEnemy += OneEnemyRemove;

        _EnemyAmount.text = TotalEnemy.ToString();
        _TurretAmount.text = TotalTurret.ToString();
    }

    public void OneTurretRemove()
    {
        TotalTurret = TotalTurret - 1; 
        _TurretAmount.text = TotalTurret.ToString();
        if (TotalTurret <= 0)
        {
            OnGameEndEvent?.Invoke();
            _winnerIs.text = "Enemy win!";
            _panelWinLose.gameObject.SetActive(true);
            //_panelMain.gameObject.SetActive(false);
        }
    }
    public void OneEnemyRemove()
    {
        TotalEnemy = TotalEnemy - 1;
        _EnemyAmount.text = TotalEnemy.ToString();
        if (TotalEnemy <= 0)
        {
            OnGameEndEvent?.Invoke();
            _winnerIs.text = "Turret win!";
            _panelWinLose.gameObject.SetActive(true);
           // _panelMain.gameObject.SetActive(false); 
}
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Again()
    {
        TotalEnemy = 5;
        TotalTurret = 5;
        OnGameAgainEvent?.Invoke();

}

}
