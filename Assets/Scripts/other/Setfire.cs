using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setfire : MonoBehaviour
{
    public ParticleSystem setFire;

    // Update is called once per frame
    void Update()
    {
        setFire.Play();
    }
}
