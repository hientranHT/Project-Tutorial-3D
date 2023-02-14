using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb2d;

    Transform transformPlayer;

    public float time = 2.0f;
    public float timer = 0f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            Destroy(gameObject);
            timer = 0;
        }

    }

    public void Launch(Vector3 direction, float force, float maxTime)
    {
        rb2d.AddForce(direction * force);
        time = maxTime;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
