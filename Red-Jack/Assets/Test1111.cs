using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test1111 : MonoBehaviour
{
    // GameObject parents
    private GameObject Check1;
    private GameObject Check2;
    private GameObject Check3;
    private GameObject Check4;

    // GameObject childs
    private GameObject Child1;
    private GameObject Child2;
    private GameObject Child3;
    void Start()
    {
        Check1 = GameObject.Find("Check1");
        Check2 = GameObject.Find("Check2");
        Check3 = GameObject.Find("Check3");
        Check4 = GameObject.Find("Check4");

        Child1 = GameObject.Find("Child1");
        Child2 = GameObject.Find("Child2");
        Child3 = GameObject.Find("Child3");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            Child1.transform.SetParent(Check1.transform, true);
            
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Child1.transform.SetParent(Check3.transform, true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Child1.transform.SetParent(Check4.transform, true);
        }
    }
}
