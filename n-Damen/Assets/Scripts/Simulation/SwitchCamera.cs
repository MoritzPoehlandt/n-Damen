using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Vector3 getPostionMainCamera(int index){
        Vector3 result=new Vector3(0,0,0);
        switch(index){
            case 1:
            result=new Vector3(-0.3f,4.8f,-4);
            break;
            case 2:
            result=new Vector3(0.45f,4.8f,-4);
            break;
            case 3:
            result=new Vector3(0.75f,4.8f,-4);
            break;
            case 4:
            result=new Vector3(1.5f,4.8f,-4);
            break;
            case 5:
            result=new Vector3(1.9f,4.8f,-4);
            break;
            case 6:
            result=new Vector3(2.5f,4.8f,-4);
            break;
            case 7:
            result=new Vector3(3.0f,4.8f,-4);
            break;
            case 8:
            result=new Vector3(3.4f,4.8f,-4);
            break;
            case 9:
            result=new Vector3(4.0f,4.8f,-4);
            break;
            case 10:
            result=new Vector3(4.5f,4.8f,-4);
            break;
            case 11:
            result=new Vector3(5.0f,4.8f,-4);
            break;
        }


        return result;
    }
    public Vector3 getPostionOrtCamera(int index){
        Vector3 result=new Vector3(0,0,0);
        switch(index){
            case 1:
            result=new Vector3(-0.3f,1,0.25f);
            break;
            case 2:
            result=new Vector3(0.3f,1,0.25f);
            break;
            case 3:
            result=new Vector3(0.9f,1,0.6f);
            break;
            case 4:
            result=new Vector3(1.3f,1,0.8f);
            break;
            case 5:
            result=new Vector3(1.75f,1,1.05f);
            break;
            case 6:
            result=new Vector3(2.2f,1,1.25f);
            break;
            case 7:
            result=new Vector3(2.65f,1,1.7f);
            break;
            case 8:
            result=new Vector3(2.9f,1,2.05f);
            break;
            case 9:
            result=new Vector3(3.45f,1,2.3f);
            break;
            case 10:
            result=new Vector3(4.0f,1,2.6f);
            break;
            case 11:
            result=new Vector3(4.4f,1,3.0f);
            break;
        }
        return result;
    }    
    public float setOrtCamera(int index){
        float result=5.0f;
        switch(index){
            case 1:
            result=2.5f;
            break;
            case 2:
            result=2.5f;
            break;
            case 3:
            result=2.5f;
            break;
            case 4:
            result=3.0f;
            break;
            case 5:
            result=3.8f;
            break;
            case 6:
            result=4.50f;
            break;
            case 7:
            result=5.0f;
            break;
            case 8:
            result=6.0f;
            break;
            case 9:
            result=7.5f;
            break;
            case 10:
            result=8.0f;
            break;
            case 11:
            result=8.0f;
            break;
        }
        return result;
    } 
}
