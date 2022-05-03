using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(waittodestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
      
    }
    IEnumerator waittodestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
