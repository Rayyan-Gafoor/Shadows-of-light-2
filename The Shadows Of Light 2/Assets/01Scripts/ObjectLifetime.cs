using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    public float life_time;
    
    void Start()
    {
        lifetime();
    }

    void lifetime()
    {
        Destroy(gameObject, life_time);
    }
}
