using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracode : MonoBehaviour
{

    public GameObject target;
    public Vector3 distance;

    private void Start()
    {
      
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime*5);
    }
}
