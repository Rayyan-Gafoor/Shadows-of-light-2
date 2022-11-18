using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGhosts : MonoBehaviour
{
    [Header("Dissolve")]
    public float timer;
    public float destroy_timer;
    public GameObject mesh_model;
    public Material normal_mat, dissolve_mat;
    //Renderer rend;
    SkinnedMeshRenderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = mesh_model.GetComponent<SkinnedMeshRenderer>();
        rend.enabled = true;
        rend.material = normal_mat;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(dissappear());
        }
    }

    IEnumerator dissappear()
    {
        yield return new WaitForSeconds(timer);
        Debug.Log("dissolve");
        rend.material = dissolve_mat;
        DestroyObject(this.gameObject, destroy_timer);

    }
}
