using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //effect of power of camerashake
    public float power = 0.7f;
    //controls how long the effect lasts
    public float duration = 1.0f;
    
    // Referance to camera
    public Transform camera;

    //controls how quickly to slow down
    public float slowDownAmount = 1.0f;

    //controls when to shake
    public bool shouldShake = false;

    Vector3 startPosition;

    float initialDuration;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the referance to the camera and duration
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldShake)
        {
            if(duration > 0)
            {
                //makes random input and controls how fare it will go
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                //reduces duration, once it reaches 0, it will stop shaking
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                //Resets the camera, duration, and camera position
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}
