using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarningZone : MonoBehaviour
{
    //An int that counts enemys being sighted
    public int EnemyCounter;
    public GameObject Alertext;
    //number of points that enemys receive for being sighted
    public int EnemysSighted = 1;
    //check enemys health when its sighted
    EnemyHealth enemyhealth;


    void Awake()
    {
        enemyhealth = GetComponent<EnemyHealth>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCounter == 0)
       {
           Debug.Log("Enemy is not here");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyCounter++;
            enemy.GetComponent<EnemyHealth>().Sighted(EnemysSighted);
            
            Debug.Log("Enemy is here!");

            //  Alertext.SetActive(true);
      //  }
        //if (other.gameObject.tag != "Enemy")
       // {
           // Alertext.SetActive(false);
        }
    }

    public void RemoveCounterpoints(int amount)
    {
        EnemyCounter -= amount;
        Debug.Log("Points removed from Warning Zone");
    }

}

   
