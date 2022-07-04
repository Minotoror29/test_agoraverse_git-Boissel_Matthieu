using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    private GameManager gm;

    private Vector3 mousePos;

    [SerializeField] private LayerMask groundLM;
    [SerializeField] private LayerMask itemLM;

    [HideInInspector] public Vector3 itemPosition;
    public Material greenMaterial;
    public Material redMaterial;
    [HideInInspector] public bool canPlace = true;
    [SerializeField] private float rotationSpeed;

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

            if (gm.selectedItem != null)
            {
                gm.selectedItem.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * rotationSpeed, 0));

                if (Input.GetMouseButtonDown(0))
                {
                    if (!canPlace)
                    {
                        return;
                    }

                    Instantiate(gm.selectedItem.GetComponent<ItemPreview>().item, gm.selectedItem.transform.position, gm.selectedItem.transform.rotation);
                    Destroy(gm.selectedItem);
                }
            }
        }
        
        if (gm.selectedItem == null)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemLM))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gm.selectedItem = Instantiate(hit.transform.GetComponent<Item>().itemPreview, itemPosition, hit.transform.rotation);
                    Destroy(hit.transform.gameObject);
                } else if (Input.GetMouseButtonDown(1))
                {
                    hit.transform.GetComponent<Item>().ChangeMaterial();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(gm.selectedItem);
        }
    }
}
