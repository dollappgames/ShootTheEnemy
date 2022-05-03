using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyscript : MonoBehaviour
{
   
    //enemy radius  
    public float lookradius = 10f;
   // public float attackradius = 10f;
    public GameObject target;
    //enemy radius  
    public Animator animator;
    NavMeshAgent agent;
   public character ccharacter;
    //enemy death particle 
    public ParticleSystem deathparticle;
    //enemy death particle 
    // Start is called before the first frame update
    public enemycountbar enemybar;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemy radius  
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < lookradius)
        {


            Vector3 toplayer = transform.position - target.transform.position;
            Vector3 newpos = transform.position - toplayer;
            agent.SetDestination(newpos);
            animator.SetBool("run", true);

        }  //enemy radius  



        else
        {
            animator.SetBool("run", false);


        }
       // if (distance <= attackradius)
        {

         //   animator.SetBool("attack", true);
           // animator.SetBool("run", false);
        }

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (this != null)
            {
                StartCoroutine(waittodie());
            }
        }   
            if (other.gameObject.name == "area")
        {
            if (this != null)
            {

                if (ccharacter.isinarea == true)
                {
                    StartCoroutine(waittodie());
                }        
            }        
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "area")
        {
            if (this != null)
            {
                if (ccharacter.isinarea == true)
                {
                    StartCoroutine(waittodie());
                }
            }
        }
    }
    IEnumerator waittodie()
    {
        enemybar.enemys++;
        deathparticle.Play();
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(0.2f);
        ccharacter.deathnumber++;
        Destroy(gameObject);
    } //enemy radius  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
        //Gizmos.color = Color.yellow;
      //  Gizmos.DrawWireSphere(transform.position, attackradius);
    }
    //enemy radius
  
}
