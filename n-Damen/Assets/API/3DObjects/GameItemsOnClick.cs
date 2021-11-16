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
        freeGame.setQueen((int)_transform.position.x, (int)_transform.position.z);
    }
}
