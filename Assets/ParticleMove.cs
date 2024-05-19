using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public Vector3 dir;


    void Start()
    {
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }
    

    
    public void move()
    {
        gameObject.transform.position += dir * Time.deltaTime * 5;// * Time.deltaTime;
        dir *= 0.9998f;
    }

    void Update()
    {
        move();
    }
}
