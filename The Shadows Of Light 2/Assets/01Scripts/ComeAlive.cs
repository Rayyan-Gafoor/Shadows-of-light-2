using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeAlive : MonoBehaviour
{
    public bool is_alive;
    public GameObject doment, alive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.is_alive == true)
        {
            alive.SetActive(true);
            doment.SetActive(false);
            is_alive=false;
        }
    }
    
}
