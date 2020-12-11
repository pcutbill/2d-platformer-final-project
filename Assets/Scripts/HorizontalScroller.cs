﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float step = 0.002f;
        var cameraPosition = transform.position;
        cameraPosition.x += step;
        if(cameraPosition.x > 150f)
        {
            cameraPosition.x = 150f;
        }

        transform.position = cameraPosition;
    }
}
