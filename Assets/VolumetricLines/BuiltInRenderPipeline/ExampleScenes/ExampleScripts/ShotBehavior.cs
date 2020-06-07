using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.

        float step = speed * Time.deltaTime;
        //checks to see if the target is set
        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                //explodes on target
                explode();
                return;
            }

            //Moves towards target
            //IF it has no yet hit the target, set the position to where the ray cast has hit
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }
    public void setTarget(Vector3 target)
    {
        m_target = target;
    }
    void explode()
    {
        if (collisionExplosion != null)
        {
            //instantiats an explosion
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            //Destroys the laser and explosion
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }
}