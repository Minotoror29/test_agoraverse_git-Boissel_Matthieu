using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    private GameManager gm;

    private Vector3 mousePos;

    [SerializeField] private LayerMask groundLM;

    public Vector3 itemPosition;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLM))
        {
            itemPosition = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(gm.selectedItem.GetComponent<ItemPreview>().item, gm.selectedItem.transform.position, gm.selectedItem.transform.rotation);
                Destroy(gm.selectedItem);
            }
        }
    }
}
