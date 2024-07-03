using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public float flapStrength;
    public float rotationForce;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            _rigidbody2D.velocity = Vector2.up * flapStrength;

            if (gameObject.transform.rotation.z != rotationForce)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, rotationForce);
            }
        }

        Console.WriteLine(_rigidbody2D.velocity);

        if (_rigidbody2D.velocity.y <= 0 && gameObject.transform.rotation.z != -rotationForce)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotationForce);
        }
    }
}
