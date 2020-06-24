using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPowerup : MonoBehaviour
{
    ScoringSystem scoringsystem;
    //The speed that the powerup rotates until picked up
    public float speed;



    PlayerHealth playerhealth;

    public int Scorevalue;
    //game object that instantiates firworks when shot
    public GameObject fireworks;

    // Start is called before the first frame update
    void awake()
    {
        scoringsystem = GetComponent<ScoringSystem>();
        playerhealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
        if(ScoringSystem.end == true)
        {
            Destroy(gameObject);
        }
    }

    public void GetPoints()
    {
        ScoringSystem.score += Scorevalue;
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log(" I got points!");
    }

    public void OnParticleCollision(GameObject other)
    {
        ScoringSystem.score += Scorevalue;
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log(" I got points!");
    }
}


