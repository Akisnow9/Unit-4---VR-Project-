﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotate : MonoBehaviour
{
   public float speed = 100.0f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( new Vector3(0,0, speed));
    }
}
