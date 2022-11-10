using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float minX = -50f, minY=-50f, maxX=100f, maxY=100f;
    public float jumpHeight = 0.5f;

    private Rigidbody2D rBody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // rBody.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        // initial empty state, stay here until finish falling
        if (animator.GetInteger("AnimState") == 0)
            return;

        // print(Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            animator.SetInteger("AnimState", 1);
            // rBody.velocity = new Vector2(0f, 0f);
            return;
        }

        float horiz, vert;

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // var absVelx = Mathf.Abs(rBody.velocity.x);
        // var absVely = Mathf.Abs(rBody.velocity.y);

        if (Mathf.Abs(horiz) > .1f)
        {
            transform.localScale = new Vector3(horiz > 0 ? 1 : -1, 1, 1);
            animator.SetInteger("AnimState", 2);
            Vector2 newVelocity = new Vector2(horiz, 0f);
            // print(horiz);
            rBody.velocity = newVelocity * speed;
            // print(rBody.velocity);
        }

        /*
        float newX, newY;
        newX = Mathf.Clamp(rBody.position.x, minX, maxX);
        newY = Mathf.Clamp(rBody.position.y, minY, maxY);

        rBody.position = new Vector2(newX, newY);
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (animator.GetInteger("AnimState") == 0)
        {
            animator.SetInteger("AnimState", 1);
        }
        print("Collision Enter");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Collision Exit");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
