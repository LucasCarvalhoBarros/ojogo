using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    private Rigidbody2D rigidbody;

    public bool isJumping;
    public bool doubleJumping;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rigidbody.AddForce(new Vector2(0f,JumpForce), ForceMode2D.Impulse);
                doubleJumping = true;
            }
            else
            {
                if(doubleJumping)
                {
                    rigidbody.AddForce(new Vector2(0f,JumpForce), ForceMode2D.Impulse);
                    doubleJumping = false;
                }
            }
            
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;        
    }

    void OnCollisionEnter2D(Collision2D pColission2D)
    {
        if(pColission2D.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D pColission2D)
    {
        if(pColission2D.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
