using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerA : PlayerBase
{
    private float iceJumpSpeed;
    public float waterJumpSpeed = 300;
    public AnimatorOverrideController iceAnim;
    public AnimatorOverrideController waterAnim;
    public AnimatorOverrideController airAnim;
    public LayerMask mask;
    private AState state = AState.ice;
    void Start()
    {
        iceJumpSpeed = jumpSpeed;

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
        if (!playerControl) return;
        hor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
        Jump();
        StateSwitch();


    }
    void FixedUpdate()
    {

        Movement();

    }

    private void StateSwitch()
    {
        if (state == AState.ice)
        {
            if (temperature >= 0)
            {
                StartCoroutine(IceToWater());
            }

        }
        else if (state == AState.water)
        {
            if (temperature < 0)
            {
                StartCoroutine(WaterToIce());
            }
            else if (temperature > 10)
            {
                StartCoroutine(WaterToAir());
            }

        }
        else if (state == AState.air)
        {
            // if (temperature <= 10)
            // {
            //     StartCoroutine(WaterToIce());
            // }
        }
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
        if (state == AState.air || boxCollider.IsTouchingLayers(mask)) return;
        if (rb.velocity.y == 0)
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
    private IEnumerator IceToWater()
    {
        //失去控制
        playerControl = false;
        //切换动画
        animator.SetTrigger("icetowater");
        //修改状态
        state = AState.water;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = waterAnim;
        animator.Play("Idle");
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;

        //恢复控制
        playerControl = true;
    }
    private IEnumerator WaterToIce()
    {
        //失去控制
        playerControl = false;
        //切换动画
        animator.SetTrigger("watertoice");
        //修改状态
        state = AState.ice;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = iceAnim;
        animator.Play("Idle");
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;

        //恢复控制
        playerControl = true;
    }
    private IEnumerator WaterToAir()
    {
        //失去控制
        playerControl = false;
        //切换动画
        animator.SetTrigger("watertoair");
        //修改状态
        state = AState.air;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = airAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.2f);
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        //重力
        rb.gravityScale = -1;
        //恢复控制
        playerControl = true;
    }

}
