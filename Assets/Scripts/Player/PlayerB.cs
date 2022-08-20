using UnityEngine.UI;

using UnityEngine;

public class PlayerB : PlayerBase
{
    public float hp=100;
    public bool IsFrozen;

    void Start()
    {
        IsFrozen = false;
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
        if (IsFrozen) return;
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

        if (IsFrozen) return;
        rb.velocity = new Vector2(hor * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    private void Jump()
    {
        if (IsFrozen) return;
        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
        }

    }
}
