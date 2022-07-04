using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    private GameManager gm;
    private PlaceItem pi;

    public GameObject item;

    private void Start()
    {
        gm = GameManager.Instance;
        pi = gm.GetComponent<PlaceItem>();
    }

    private void Update()
    {
        transform.position = pi.itemPosition;
    }
}
