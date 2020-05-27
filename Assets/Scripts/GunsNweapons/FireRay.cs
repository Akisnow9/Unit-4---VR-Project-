using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRay : MonoBehaviour
{
	public GameObject raycastMarker = null;

	public int ammoCount = 100;
	public int clipSize = 15;
	public int clipCount = 5;

	public Text ammoText;
	public Text clipText;

	public float timeBetweenBullets = 0.2f;
	public bool canShoot = true;


	void Start()
	{
		//UpdateText ();
	}

	private void UpdateText()
	{
		//assigns the number of ammo and clips you have on the UI 
	//	ammoText.text = ammoCount.ToString ();
	//	clipText.text = clipCount.ToString ();
	}

	private void ResetShooting()
	{
		canShoot = true;
	}

	//Reloads the weopon when empty
	private void Reload()
	{
		ammoCount += clipCount;

		if (ammoCount > clipSize) 
		{
			clipCount = clipSize;
			ammoCount -= clipSize;
		
		} else {
			clipCount = ammoCount;
			ammoCount = 0;
		}

		UpdateText ();
	}
    
    // Update is called once per frame
    void Update()
    {
		//A physics hit object to store info we are going to get about where the ray hits
		RaycastHit hit;

		//The distance of the ray that we are using
		float distanceOfRay = 100f;
    
	    //Cast the ray and check if it hits anything
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceOfRay)) 
		{
			//Reloads weopon
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Reload ();
			}

			//This displays the name of the object
			//Debug.Log (hit.transform.name);

			if (Input.GetMouseButton(0)) 
			{
				if (clipCount <= 0) 
				{
					return;
				}

				if (canShoot == false) 
				{
					return;
				}

				canShoot = false;
				Invoke ("ResetShooting", timeBetweenBullets);

				clipCount--;
				UpdateText ();

				//Moves the referance GameObject at a position where ever another game object you clicked on
				raycastMarker.transform.position = hit.point;
				raycastMarker.GetComponentInChildren<ParticleSystem>().Play();
				Debug.Log ("Dusty");

				//when shot, it will show the transform positon vector 3 of where the object has been located 
				Debug.Log (hit.point);

				//Moves the object up
				//hit.transform.position = hit.transform.position + Vector3.up;

				//Scales the object - making it smaller
				//hit.transform.localScale = hit.transform.localScale * 0.9f;

				//deactivates the object
					//hit.transform.gameObject.SetActive(false);

				//Destory the object
				//	Destroy(hit.transform.gameObject);

				//Changes the colour of the object by the material in random colors
				//	hit.transform.gameObject.GetComponent<Renderer> ().material.color =
				//	new Color(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range(0f, 1f));
		
		
			}
		}
	
		//Draw a ray in the editor

		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);
	}
}
