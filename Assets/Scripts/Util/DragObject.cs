
using System;
using UnityEngine;
public class DragObject : MonoBehaviour
{

    public static event Action<Turret> OnTurretDownEvent;
    public static event Action         OnTurretUpEvent;

    [SerializeField] Turret turret;
    private Camera cam;
    private bool isDragging = false;
    private float zCoord;
    public LayerMask floorLayer; 

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        zCoord = cam.WorldToScreenPoint(transform.position).z;
        OnTurretDownEvent?.Invoke(turret);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = zCoord;

            Vector3 worldPos = cam.ScreenToWorldPoint(mousePoint);

            // Cast ray downward from above the world position
            Ray ray = new Ray(worldPos + Vector3.up * 10f, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, 20f, floorLayer))
            {
                transform.position = hit.point;
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        OnTurretUpEvent?.Invoke();
    }
}
