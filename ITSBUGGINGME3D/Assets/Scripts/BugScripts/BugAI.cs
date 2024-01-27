using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;


public class BugAI : MonoBehaviour
{
    //Reference HighScore script
    public HighScore health;

    NavMeshAgent agent;
    [SerializeField]
    //Where we want the AI to go
    GameObject target;
    [SerializeField]
    AnimationCurve rotationLength;

    //Set the nav agent component
    //Set the end position as destinatino (it will start to move there)
    void Start()
    {
        health = GameObject.Find("ScoreManager").GetComponent<HighScore>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    //Update is called once per frame
    void Update()
    {
        //When AI is stopped, destroy self.
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Destroy(this.gameObject);
            //Decrease health point by 1
            health.Healthpoint = health.Healthpoint - 1;
            //Prevent health from going below zero
            if (health.Healthpoint < 0) 
            {
                health.Healthpoint = 0;
            }
        }
    }
    
    //Draws a yellow line along the agents path
    void OnDrawGizmosSelected()
    {
        var nav = GetComponent<NavMeshAgent>();
        if( nav == null || nav.path == null )
            return;

        var line = this.GetComponent<LineRenderer>();
        if( line == null )
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material( Shader.Find( "Sprites/Default" ) ) { color = Color.yellow };
            line.SetWidth( 0.5f, 0.5f );
            line.SetColors( Color.yellow, Color.yellow );
        }

        var path = nav.path;

        line.SetVertexCount( path.corners.Length );

        for( int i = 0; i < path.corners.Length; i++ )
        {
            line.SetPosition( i, path.corners[ i ] );
        }
    }
}