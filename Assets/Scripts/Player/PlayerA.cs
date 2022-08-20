using UnityEngine;
using UnityEngine.UI;

public class PlayerA : PlayerBase
{
    public AState state=AState.water;
    public bool IsFrozen;

    void Start()
    {
        IsFrozen = false;
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
        if (IsFrozen) return;
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
