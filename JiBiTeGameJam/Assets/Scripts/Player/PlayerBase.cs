using UnityEngine.UI;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected bool playerControl=true;
    public float speed;
    public float jumpSpeed;
    public float temperature = 0;
    protected Slider slider_Heat;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected BoxCollider2D boxCollider;
    protected SpriteRenderer spriteRenderer;
    protected float hor;
    protected bool jump;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


}
