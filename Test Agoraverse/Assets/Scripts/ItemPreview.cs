using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    private GameManager gm;
    private PlaceItem pi;

    [SerializeField] private MeshRenderer mRenderer;

    public GameObject item;

    private List<GameObject> collisions;

    private void Start()
    {
        gm = GameManager.Instance;
        pi = gm.GetComponent<PlaceItem>();

        collisions = new List<GameObject>();

        mRenderer.material = pi.greenMaterial;

        transform.position = pi.itemPosition;
    }

    private void Update()
    {
        transform.position = pi.itemPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        collisions.Add(other.gameObject);

        if (collisions.Count >= 1)
        {
            mRenderer.material = pi.redMaterial;
            pi.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.gameObject);

        if (collisions.Count == 0)
        {
            mRenderer.material = pi.greenMaterial;
            pi.canPlace = true;
        }
    }
}
