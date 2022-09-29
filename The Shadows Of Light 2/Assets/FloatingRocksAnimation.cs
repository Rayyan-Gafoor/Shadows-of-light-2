using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRocksAnimation : MonoBehaviour
{
    public bool floater, spiral, rotate = false;
    public float float_speed, spiral_speed, rotation_speed = 0;
    public GameObject central_point;

    [Header("floating parameters")]
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        /*floater = false;
        spiral = false;
        rotate = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (spiral == true)
        {
            spiraling();
        }
        if (floater == true)
        {
            floating();
        }
    
        if (rotate == true)
        {
            rotating();
        }

    }
    void floating()
    {
        tempPos = central_point.transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        
        transform.position = tempPos;
    }
    void spiraling()
    {
        transform.RotateAround(central_point.transform.position, new Vector3(0, 1, 0), spiral_speed * Time.deltaTime);
        //transform.position += new Vector3(transform.position.x, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, transform.position.z);
    }
    void rotating()
    {
        transform.Rotate(new Vector3(0, rotation_speed, 0) * Time.deltaTime);
    }
  
}
