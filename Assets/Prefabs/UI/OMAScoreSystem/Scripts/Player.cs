﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoringSystem.score += 1000;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScoringSystem.end = true;

        }

    }
}
