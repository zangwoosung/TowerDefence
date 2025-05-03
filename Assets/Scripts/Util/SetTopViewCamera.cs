using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SetTopViewCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetObj;
    public float duration = 1.5f;
    public Button topButton;
    public Button sideButton;
    Vector3 targetPos;
    Quaternion targetRot;

    Vector3 oriPos;
    Quaternion oriRot;


    private void Start()
    {
        targetPos = targetObj.position;
        targetRot = targetObj.rotation;

        oriPos = mainCamera.transform.position;
        oriRot = mainCamera.transform.rotation;
        topButton.interactable = true;
        sideButton.interactable = false;
    }

    public void MoveCameraTopView()
    {
        topButton.interactable = false;
        sideButton.interactable = false;
        StartCoroutine(SmoothTransition(targetPos, targetRot));
    }
    public void MoveCameraSideView()
    {
        topButton.interactable = false;
        sideButton.interactable = false;
        StartCoroutine(SmoothTransition(oriPos, oriRot));
    }

    private IEnumerator SmoothTransition(Vector3 targetPos, Quaternion targetRot)
    {
        Vector3 startPos = mainCamera.transform.position;
        Quaternion startRot = mainCamera.transform.rotation;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPos;
        mainCamera.transform.rotation = targetRot;

       
        if (mainCamera.transform.position == oriPos)
        {
            topButton.interactable = true;
        }
        else
        {
            sideButton.interactable = true;
        }

    }


    public void SimpleTopView()
    {
        mainCamera.transform.position = targetPos;
        mainCamera.transform.rotation = targetRot;
    }
    public void SimpleSideView()
    {
        mainCamera.transform.position = oriPos;
        mainCamera.transform.rotation = oriRot;
    }
}

