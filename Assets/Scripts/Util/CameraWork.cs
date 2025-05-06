using UnityEngine;

public class CameraWork : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform _world;
    /// //Camera cam;   
    /// </summary>
    [SerializeField] float zoomSpeed = 10f;
    [SerializeField] float minFOV = 15f;
    [SerializeField] float maxFOV = 60f;
    [SerializeField] float moveSpeed = 10f;


    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.fieldOfView -= scroll * zoomSpeed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrow

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        _world.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
