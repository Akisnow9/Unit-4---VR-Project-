using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTest : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger has found the player");
        }
    }
}
