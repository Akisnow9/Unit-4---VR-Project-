using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZem : MonoBehaviour
{
    ScoringSystem scoringsystem;
    public GameObject zem;

    public int Scorevalue;

    //game object that instantiates firworks when shot
    public GameObject fireworks;
    // Start is called before the first frame update

    void awake()
    {
        scoringsystem = GetComponent<ScoringSystem>();
    }

        public void activiatezem()
    {
        ScoringSystem.score += Scorevalue;
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        zem.SetActive(true);
        Debug.Log("Unleash the Zanics");
        Destroy(gameObject);
    }
}
