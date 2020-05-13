using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PipeGenerator PipeGenerator;
    private Transform cameraTransform = null;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.IsAlive)
        {
            transform.position = new Vector3(transform.position.x - 0.010f, transform.position.y, transform.position.z);
            if (transform.position.x < cameraTransform.position.x - 10)
            {
                var nextPos = PipeGenerator.GetNextPosition(transform.position.x);
                transform.position = new Vector3(nextPos.x, nextPos.y, transform.position.z);
            }
        }
    }
}
