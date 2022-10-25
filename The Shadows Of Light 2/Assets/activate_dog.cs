using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_dog : MonoBehaviour
{
    public GameObject fox_object, fox_object2;
    
    // Start is called before the first frame update
    void Start()
    {
        fox_object.SetActive(false);
        fox_object2.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        fox_object.SetActive(true);
        fox_object2.SetActive(true);
    }

}
