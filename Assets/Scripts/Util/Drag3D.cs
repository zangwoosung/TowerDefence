using UnityEngine;

public class Drag3D : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private float distanceToCamera;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        distanceToCamera = Vector3.Distance(transform.position, cam.transform.position);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 newPos = ray.GetPoint(distanceToCamera);
            transform.position = newPos;
        }
    }
}
