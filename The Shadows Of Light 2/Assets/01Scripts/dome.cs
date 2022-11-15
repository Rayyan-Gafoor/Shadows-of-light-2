using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dome : MonoBehaviour
{
    public bool active;

    [Header("material Changer")]
    public GameObject normal_mesh;
    public GameObject dissolve_mesh;


    // Start is called before the first frame update
    void Start()
    {
        //normal_mesh.SetActive(true);
        dissolve_mesh.SetActive(false);
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (normal_mesh.activeSelf)
        {
            deactivate_dome();
        }
        if (active == false)
        {
            dissolve_mesh.SetActive(true);
            normal_mesh.SetActive(false);
        }
        
    }
    public void deactivate_dome()
    {
        if (GameObject.Find("MainEnemy") == null)
        {
            active = false;
        }
       
    }
}
