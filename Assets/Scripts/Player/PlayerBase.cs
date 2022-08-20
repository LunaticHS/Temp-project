using UnityEngine.UI;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public Slider slider_Heat;
    public float temperature = 0;

    protected Rigidbody2D rb;
    protected float hor;
    protected bool isJump;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  

}
