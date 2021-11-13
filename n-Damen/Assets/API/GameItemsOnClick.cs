using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemsOnClick : MonoBehaviour
{
    Transform _transform;

    private void Start()
    {
        _transform = transform;
//        Debug.Log(_transform.position);
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            //Select stage    
    //            if (hit.transform.name == transform.name)
    //            {
    //                Debug.Log("test");
    //            }
    //        }
    //    }
    //}
}
