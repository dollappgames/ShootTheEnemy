using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatenemyplayer : MonoBehaviour
{  
    public List<GameObject> targets;
    public bool isinarea;
    void Update()
    {
        List<GameObject> targets = new List<GameObject>();
        if(isinarea==true)
        {
            FindClosestEnemy();
        }      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isinarea = true;
           targets.Add(gameObject);         
        }
      else
        {
            isinarea = false;
        }      
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isinarea = true;
           // targets.Add(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isinarea = false;
            targets.Remove(gameObject);
        }
    }
 public void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
               
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                transform.LookAt(closestEnemy.transform);
            }
        }      
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }
}


