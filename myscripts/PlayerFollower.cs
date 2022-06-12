using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerposition;
    public Transform cameraposition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerposition.position.y>cameraposition.position.y)
        {
            cameraposition.position = new Vector3(cameraposition.position.x, playerposition.position.y, cameraposition.position.z);
        }
    }
}
