using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemsOnClick : MonoBehaviour
{
    Transform _transform;

    public FreeGame freeGame;

    private void Start()
    {
        _transform = transform;
        _transform.gameObject.AddComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        freeGame = FindObjectOfType<FreeGame>();
        if (GameObject.Find((int)_transform.position.x + "_" + (int)_transform.position.z) != null) {
            freeGame.removeQuee((int)_transform.position.x, (int)_transform.position.z);
        } else
        {
            freeGame.setQueen((int)_transform.position.x, (int)_transform.position.z);
        }
    }
}
