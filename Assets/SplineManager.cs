using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class SplineManager : MonoBehaviour
{

    public Spline mySpline;
    public SplineContainer mySplineContainer;
    //public SplineAnimate mySplineAnimate;
    public GameObject myCube;

    // Start is called before the first frame update
    void Start()
    {
        //myCube.AddComponent<SplineAnimate>();
        //myCube.GetComponent<SplineAnimate>().enabled = false; ;
    }
    IEnumerator ChangeSpline()
    {
        myCube.GetComponent<SplineAnimate>().enabled = false;

        SplineAnimate an = myCube.GetComponent<SplineAnimate>();
        Destroy(an);
        yield return new WaitForSeconds(1f);
        
        Debug.Log("AAAaaaaa");
        myCube.AddComponent<SplineAnimate>();
        yield return new WaitForSeconds(1f);
        myCube.GetComponent<SplineAnimate>().Container.Spline = mySplineContainer.Spline;
        //myCube.GetComponent<SplineAnimate>() = mySplineAnimateue;
        //myCube.GetComponent<SplineAnimate>().enabled=true;
        myCube.GetComponent<SplineAnimate>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(ChangeSpline()); 
           
        }
    }
}
