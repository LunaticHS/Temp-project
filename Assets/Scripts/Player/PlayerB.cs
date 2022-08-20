using UnityEngine.UI;

using UnityEngine;

public class PlayerB : PlayerBase
{
    public float hp=100;
    void Start()
    {
        GameObject sliObj = GameObject.Find("Slider_Heat_Player2");
        if (sliObj)
        {
            slider_Heat = sliObj.GetComponent<Slider>();
        }
        else
            print("zhaobudao ");
    }
    void Update()
    {
        hor = Input.GetAxisRaw("HorizontalB");
        isJump = Input.GetKeyDown(KeyCode.UpArrow);
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
