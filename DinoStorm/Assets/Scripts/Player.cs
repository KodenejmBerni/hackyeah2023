using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    public Camera cam;

    public float initialVelocity;
    public float rotationSpeed;
    public bool firstClickDone;

    public static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, 0);
        animator.SetFloat("angle", 0);
        firstClickDone = false;

        initialVelocity = 3;
        rotationSpeed = (float)0.05;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(player_pos.x, player_pos.y, GetComponent<SpriteRenderer>().bounds.min.y * 0.001f);
        if (firstClickDone == false && Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, 1) * initialVelocity;
            firstClickDone = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;

            Vector2 perpendicularToRaptorVelocity = Vector2.Perpendicular(rb.velocity);
            perpendicularToRaptorVelocity.Normalize();

            if (touchPos.x < cam.pixelWidth / 2)
            {
                rb.velocity = rotate(rb.velocity, rotationSpeed);
            }
            else
            {
                rb.velocity = rotate(rb.velocity, -rotationSpeed);
            }

            //Set new angle
            float angle = Vector2.SignedAngle(rb.velocity, new Vector2(0, 1));
            if (angle < 0)
            {
                angle = angle + 360;
            }
            animator.SetFloat("angle", angle);
        }
    }
}
