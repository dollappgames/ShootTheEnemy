using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class character : MonoBehaviour
{
  

    //joystic for move
    public VariableJoystick movejoystick;
    //joystic for move
    //joystic for setactive false
    public Joystick joystick;
    //joystic for setactive false

    //enemys death list
    public int deathnumber;
    public int deathend;
    //enemys death list
    //move speed
    [SerializeField] public float moveH, moveV, speedmove = 8;
    //move speed
    private Rigidbody rb;
   public Animator animator;
    
    public bool isrunning;
    //playersarea
    public GameObject playersarea;
    public GameObject explosion;
    public lookatenemyplayer playerlookatenemy;
    public bool isinarea;
    Vector3 temp;
    //playersarea

    //gunparticle
    public ParticleSystem gunparticle;
    //gunparticle

   
    //finish
    public GameObject finish;
    //finish

    NavMeshAgent agent;
    void Start()
    {
       

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
       
        if (deathnumber==deathend)
        {
            finish.SetActive(true);
        }

        moveH = movejoystick.Horizontal;
            moveV = movejoystick.Vertical;

            Vector3 dir = new Vector3(moveH, 0, moveV);
            rb.velocity = new Vector3(moveH * speedmove, rb.velocity.y, moveV * speedmove);
            if (dir != Vector3.zero)
        {
            //areascale
            temp = playersarea.transform.localScale;
            temp.x += Time.deltaTime;
            playersarea.transform.localScale = temp;
            temp = playersarea.transform.localScale;
            temp.z += Time.deltaTime;
            playersarea.transform.localScale = temp;
            //areascale

            isrunning = true;
              animator.SetBool("run", true);
             animator.SetFloat("speed", dir.magnitude);
            // transform.LookAt(transform.position + dir);
            explosion.SetActive(false);
        }
        else
        {

            StartCoroutine(waitexplosion());
            isrunning = false;
              animator.SetBool("run", false);
        }

        if (playerlookatenemy.isinarea == false)
            {

            transform.LookAt(transform.position + dir);
        }
        if (playerlookatenemy.isinarea == true)
        {
            gunparticle.Play();
        }
      

    }

  
  


    IEnumerator waitexplosion()
    {
      
        isinarea = true;
        explosion.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        playersarea.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0, 0, 0));
        explosion.SetActive(false);
        isinarea = false;
    }
}
