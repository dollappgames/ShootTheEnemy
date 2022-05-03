using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    GameObject enemys;
    public Transform bulletspawnpoint;
    public GameObject bulletprefab;
    public float bulletspeed = 10;
    public float shootradius = 10f;
    public lookatenemyplayer lookplayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {





        if(lookplayer.isinarea==true)
        {
            var bullet = Instantiate(bulletprefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletspawnpoint.forward * bulletspeed;

        }
        
    }
            
        
    
  
}
