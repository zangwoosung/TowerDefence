using System.Collections;
using UnityEngine;
public class SetTopViewCamera : MonoBehaviour
{
    public Camera mainCamera;     
    public Transform targetObj;

    Vector3 targetPos;
    Quaternion targetRot; 

    Vector3 oriPos;
    Quaternion oriRot;
    float moveSpeed = 5.1f;

    private void Start()
    {
        targetPos = targetObj.position;
        targetRot = targetObj.rotation;
        
        oriPos = mainCamera.transform.position;
        oriRot = mainCamera.transform.rotation;

    }

    IEnumerator ChangeCameraPosCor(Vector3 pos)
    {
        while (true)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, pos, moveSpeed * Time.deltaTime);

            yield return null;

            float diffe = Mathf.Abs(mainCamera.transform.position.x - pos.x);
            if (diffe < 0.01f) break;
        }
    }
    IEnumerator ChangeCameraRotCor(Quaternion rot)
    {
        while (true)
        {
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, rot, moveSpeed * Time.deltaTime);

            yield return null;

            float diffe = Mathf.Abs(mainCamera.transform.rotation.x - rot.x);
            if (diffe < 0.01f) break;
        }
    }

    public void TopView()
    {
        StartCoroutine(ChangeCameraPosCor(targetPos));
        StartCoroutine(ChangeCameraRotCor(targetRot));
    }
    public void SideView()
    {
        StartCoroutine(ChangeCameraPosCor(oriPos));
        StartCoroutine(ChangeCameraRotCor(oriRot));
    }
    public void SimpleTopView()
    {
        mainCamera.transform.position= targetPos;
        mainCamera.transform.rotation= targetRot;
    }
    public void SimpleSideView()
    {
        mainCamera.transform.position = oriPos;
        mainCamera.transform.rotation = oriRot;
    }
}

