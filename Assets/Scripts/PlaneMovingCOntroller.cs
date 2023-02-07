using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovingCOntroller : MonoBehaviour
{
    //
    private Transform transform;

    //
    public float moving = 20.0f;
    bool isMovingLeft = true;
    float speed = 10f;
    Vector3 newPosision = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMovingLeft) 
        {
            newPosision = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); ;
        }
        else
        {
            newPosision = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z); ;
        }
        transform.position = newPosision;
        
        if(transform.position.x <= -moving)
        {
            isMovingLeft = false;
        }
        if (transform.position.x >= moving)
        {
            isMovingLeft = true;
        }
    }
}
