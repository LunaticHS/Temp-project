using UnityEngine.UI;

using UnityEngine;

public class PlayerB : PlayerBase
{
    public float hp = 100;
    public LayerMask mask;
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
        jump = Input.GetKeyDown(KeyCode.UpArrow);
        Jump();
    }
    void FixedUpdate()
    {

        Movement();

    }

    private void Movement()
    {
        rb.velocity = new Vector2(hor * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("move", hor);
        if (hor != 0)
        {
            transform.localScale = new Vector2(-hor, 1);
        }
    }
    private void Jump()
    {
        if (rb.velocity.y == 0 || boxCollider.IsTouchingLayers(mask))
        {
            if (jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
                animator.SetBool("jump", true);
            }
            else
                animator.SetBool("jump", false);
        }
    }
}
