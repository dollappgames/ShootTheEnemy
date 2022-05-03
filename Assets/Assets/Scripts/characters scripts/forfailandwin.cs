using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forfailandwin : MonoBehaviour
{
    public GameObject fail;
    public GameObject win;
    public character ccharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="enemy")
        {
            StartCoroutine(failscreen());
           
        }
        if (other.gameObject.name == "finish")
        {
            StartCoroutine(winscreen());
        }
    }
    public IEnumerator winscreen()
    {
        ccharacter.animator.SetBool("dance", true);
        ccharacter.speedmove = 0;
        ccharacter.joystick.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);



       win.gameObject.SetActive(true);
    }
    public IEnumerator failscreen()
    {
        ccharacter.animator.SetBool("death", true);
        ccharacter.speedmove = 0;
        ccharacter.joystick.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);


        fail.gameObject.SetActive(true);
    }


}
