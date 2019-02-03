using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineMover : MonoBehaviour
{
    private float speedFactor = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(1, 0, 0) * speedFactor * Time.deltaTime;
    }
}
