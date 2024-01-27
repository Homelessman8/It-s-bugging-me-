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

    //Reference particle effect and click effect
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    //Reference the damage flash
    public DamageFlash flashHit;

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
                //Cast hit effect
                if (clickEffect != null)
                {
                    Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                }
                
                //Cause damage flash
                //refer to damage flash script

                //Debug.Log(hit.collider.name);
                //Destroy game object 
                Destroy(hit.transform.gameObject);
                
                livescore.Score++;

            }
            
        }
    }
   
}
