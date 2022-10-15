using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChangeTest : MonoBehaviour
{
    public Material normal_material, dissolve_material;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = normal_material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            rend.material = dissolve_material;
        }
    }
}
