using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickLore : MonoBehaviour
{
    public float disbale_time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disable());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(disbale_time);
        this.gameObject.SetActive(false); 
    }
}
