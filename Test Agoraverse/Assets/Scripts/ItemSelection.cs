using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    private GameManager gm;
    private PlaceItem pi;

    [SerializeField] private List<KeyCode> selectionKeys;

    private void Start()
    {
        gm = GameManager.Instance;
        pi = gm.GetComponent<PlaceItem>();
    }

    private void Update()
    {
        for (int i = 0; i < selectionKeys.Count; i++)
        {
            if (Input.GetKeyDown(selectionKeys[i]))
            {
                if (gm.selectedItem != null)
                {
                    Destroy(gm.selectedItem.gameObject);
                }

                gm.selectedItem = Instantiate(transform.GetChild(i).GetComponent<ItemSlot>().item, pi.itemPosition, Quaternion.identity);
            }
        }
    }
}
