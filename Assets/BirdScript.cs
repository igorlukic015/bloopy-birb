using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float flapStrength;
    public float rotationForce;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            moveBird();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                moveBird();
            }
        }

        if (birdRigidBody.velocity.y <= 0 && gameObject.transform.rotation.z != -rotationForce)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotationForce);
        }
    }

    private void moveBird()
    {
        birdRigidBody.velocity = Vector2.up * flapStrength;

        if (gameObject.transform.rotation.z != rotationForce)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, rotationForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        logic.gameOver();
        birdIsAlive = false;
    }
}
