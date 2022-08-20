using UnityEngine;
using UnityEngine.UI;

public class PlayerA : PlayerBase
{
    public AState state=AState.water;
    void Start()
    {
        GameObject sliObj = GameObject.Find("Slider_Heat_Player1");
        if (sliObj)
        {
            slider_Heat = sliObj.GetComponent<Slider>();
        }
        else
            print("zhaobudao ");
    }
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.W);
        Jump();
    }
    void FixedUpdate()
    {

        Movement();

    }

    private void Movement()
    {


        rb.velocity = new Vector2(hor * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    private void Jump()
    {
        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
        }

    }
}
