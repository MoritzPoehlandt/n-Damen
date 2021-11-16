using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemsOnClick : MonoBehaviour
{
    Transform _transform;

    private void Start()
    {
        _transform = transform;
        _transform.gameObject.AddComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        GameItems gameItems = new GameItems();
        gameItems.createQueen(_transform.position.x.ToString() + "_" + _transform.position.z.ToString(), _transform.position);
    }
}
