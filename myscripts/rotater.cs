using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public int rotationspeed;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, direction * rotationspeed*Time.deltaTime);
    }
}
