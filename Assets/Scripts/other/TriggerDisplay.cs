using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script displays the trigger in the scene to be used for prototyping
[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class TriggerDisplay : MonoBehaviour {
    //gets referance to the colors and box collider
    public Color triggerColour;
    public Color triggerWireColour;

    private BoxCollider bc;

    private void OnEnable()
    {
        //gets the box collider
        bc = GetComponent<BoxCollider>();
    }
    // These DrawGizmos functions highlight the box collider so you can see in the scene
    private void OnDrawGizmos()
    {
        RedrawBox();
    }
    private void OnDrawGizmosSelected()
    {
        RedrawBox();
    }
    //This function  draws the box and uses it to make it visible in the scene, nut not the game
    private void RedrawBox()
    {
        if (bc != null)
        {
            bc.isTrigger = true;
            Vector3 drawBoxScale = new Vector3(transform.lossyScale.x * bc.size.x, transform.lossyScale.y * bc.size.y, transform.lossyScale.z * bc.size.z);
            Vector3 tempScale = transform.worldToLocalMatrix.MultiplyPoint(transform.lossyScale);
            Vector3 drawBoxPosition = transform.localToWorldMatrix.MultiplyPoint(bc.center);

            Gizmos.matrix = Matrix4x4.TRS(drawBoxPosition, transform.rotation, drawBoxScale);
            Gizmos.color = triggerColour;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
            Gizmos.color = triggerWireColour;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }

}

