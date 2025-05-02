using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class  DeckImageManager:MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Sprite _sprite;
    [SerializeField] TextMeshProUGUI  _HPTxt;
    [SerializeField] TextMeshProUGUI _ATKTxt;
    

    private void Start()
    {
        DragObject.OnTurretDownEvent += DragObject_OnTurretDownEvent;
        DragObject.OnTurretUpEvent += DragObject_OnTurretUpEvent;

        _HPTxt.text = string.Empty;
        _ATKTxt.text = string.Empty;
    }
    private void DragObject_OnTurretUpEvent()
    {
        _HPTxt.text = string.Empty;
        _ATKTxt.text = string.Empty;
    }
    private void DragObject_OnTurretDownEvent(Turret turret)
    {
        _HPTxt.text = turret.HP.ToString();
        _ATKTxt.text = turret.ATK.ToString();  
    }
}
