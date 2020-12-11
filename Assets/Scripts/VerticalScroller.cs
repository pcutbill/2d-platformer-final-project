using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float step = 0.001f;
        var cameraPosition = transform.position;
        cameraPosition.y += step;
        transform.position = cameraPosition;
    }
}
