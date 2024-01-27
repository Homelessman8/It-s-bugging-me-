using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using System.IO;
using Unity.VisualScripting;

public enum bugType
{
    Cockcroah,
    Spider,
    Snail
}

public class BugAI : MonoBehaviour
{

    //Reference HighScore script
    public HighScore health;

    NavMeshAgent agent;
    [SerializeField]
    //Where we want the AI to go
    GameObject target;
    Vector3 randomPosition;
    public bugType bug;
    private List<int> validNumbers = new List<int> { 1, 4, 8,};
    [SerializeField]
    GameObject[] greenSplats;
    [SerializeField]
    GameObject[] yellowSplats;
    [SerializeField]
    GameObject[] orangeSplats;


    bool randomActive;
    //Set the nav agent component
    //Set the end position as destinatino (it will start to move there)
    void Start()
    {
        health = GameObject.Find("ScoreManager").GetComponent<HighScore>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        StartCoroutine(RandomMovement());
    }

    //Update is called once per frame
    void Update()
    {
        //When AI is stopped, destroy self.
        if(agent.remainingDistance <= agent.stoppingDistance && !randomActive)
        {
            Destroy(this.gameObject);
        }
        else if(agent.remainingDistance <= agent.stoppingDistance && randomActive)
        {
            randomActive = false;
            agent.SetDestination(target.transform.position);
        }

        //When AI is stopped, destroy self.
        if (agent.remainingDistance <= agent.stoppingDistance)
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

    void FixedUpdate()
    {
        var randomNumber = Random.Range(1, 100);
         if (validNumbers.Contains(randomNumber) && !randomActive)
        {
            StartCoroutine(RandomMovement());
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

    private IEnumerator RandomMovement()
    {
        randomActive = true;
        float randomOffset = Random.Range(-4, 4);
        randomPosition = gameObject.transform.position + transform.forward * 2 + transform.right * randomOffset;
        agent.SetDestination(randomPosition);
        yield return new WaitForSeconds(3);
        randomActive = false;
        agent.SetDestination(target.transform.position);
    }

    void OnDestroy()
    {
        switch(bug)
        {
            case bugType.Cockcroah:
            Instantiate(orangeSplats[Random.Range(0, 1)], transform.position + transform.up * 0.1f, transform.rotation);
            break;

            case bugType.Spider:
            Instantiate(greenSplats[Random.Range(0, 1)], transform.position + transform.up * 0.1f, transform.rotation);
            break;

            case bugType.Snail:
            Instantiate(yellowSplats[Random.Range(0, 1)], transform.position + transform.up * 0.1f, transform.rotation);
            break;
        }
        Destroy(this.gameObject);
    }
}