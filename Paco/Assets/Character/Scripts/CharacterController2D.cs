using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    //Movement variables
    [Range(0, 50)] [SerializeField] private float MovementSpeed = 20.0f;
    [Range(1, 3)] [SerializeField] private float RunningMultiplier = 3.0f;
    [SerializeField] private float HorizontalMove;
    [SerializeField] private float VerticalMove;
    [SerializeField] private bool _canMove = true;


    //Physics stuff
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FaceMousePosition();
    }

    private void MovePlayer()
    {
        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        if(_canMove)
        {
            if(HorizontalMove > 0.0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(HorizontalMove * MovementSpeed * RunningMultiplier, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(HorizontalMove * MovementSpeed, rb.velocity.y);
                }
            }
            else if(HorizontalMove < 0.0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(HorizontalMove * MovementSpeed * RunningMultiplier, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(HorizontalMove * MovementSpeed, rb.velocity.y);
                }
            }

            if (VerticalMove > 0.0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(rb.velocity.x, VerticalMove * MovementSpeed * RunningMultiplier);
                }
                else
                {
                    rb.velocity = new Vector2( rb.velocity.x, VerticalMove * MovementSpeed);
                }
            }
            else if (VerticalMove < 0.0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(rb.velocity.x, VerticalMove * MovementSpeed * RunningMultiplier);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, VerticalMove * MovementSpeed);
                }
            }
        }
    }


    private void FaceMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }

}
