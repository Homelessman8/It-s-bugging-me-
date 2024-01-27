using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    //Set the raycast length 
    public float rayLength;
    //Choose which layer to target
    public LayerMask layermask;
    public HighScore livescore;
    private void Update()
    {
       //Check if left mouse button is pressed and ask EventSystems if the cursor is over a UI object
       if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            //Use camera to create ray and give it mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Shoot ray
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                //Debug.Log(hit.collider.name);
                //Destroy game object 
                Destroy(hit.transform.gameObject);
                livescore.Score++;

            }
            
        }
    }
}
