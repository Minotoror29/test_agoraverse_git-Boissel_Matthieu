using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public MeshRenderer mRenderer;

    public GameObject itemPreview;

    [SerializeField] private List<Material> materials;
    private int material = 0;

    public void ChangeMaterial()
    {
        if (material < materials.Count - 1)
        {
            material++;
        } else
        {
            material = 0;
        }

        mRenderer.material = materials[material];
    }
}
