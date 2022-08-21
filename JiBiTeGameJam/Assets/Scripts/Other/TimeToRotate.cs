using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class TimeToRotate : MonoBehaviour
{
    public float rotateInterval = 10f;
    public float rotateSpeed;
    public float rotareAngle=180;
    public CinemachineConfiner2D confiner;
    public Collider2D[] colliders;
    private int index = 0;
    public UnityEvent onRotateFinish;
    public GameObject PlayerA;
    public GameObject PlayerB;


    private float Timer = 10;
    void Start()
    {
        confiner = FindObjectOfType<CinemachineConfiner2D>();
        //onRotateFinish.AddListener(SwitchConfiner);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= rotateInterval)
        {
            Timer = 0;
            Quaternion tar = Quaternion.Euler(0, 0, rotareAngle) * transform.rotation;
            StartCoroutine("Rotate", tar);
            freeze();
        }
    }

    IEnumerator Rotate(Quaternion tarRotation)
    {
        Transform Ta = this.PlayerA.transform.GetComponent<Transform>();
        Transform Tb = this.PlayerB.transform.GetComponent<Transform>();
        while (transform.rotation != tarRotation)
        {
            transform.rotation = Quaternion.RotateTowards
                            (transform.rotation, tarRotation, rotateSpeed * Time.deltaTime);
            Ta.rotation = Quaternion.RotateTowards
                            (Ta.rotation, tarRotation, -rotateSpeed * Time.deltaTime);
            Tb.rotation = Quaternion.RotateTowards
                            (Tb.rotation, tarRotation, -rotateSpeed * Time.deltaTime);
            yield return null;
        }
        Release();
        onRotateFinish?.Invoke();
    }
    private void SwitchConfiner()
    {
        index = (index + 1) % colliders.Length;
        confiner.m_BoundingShape2D = colliders[index];

    }

    void freeze()
    {
        Rigidbody2D rigA = this.PlayerA.GetComponent<Rigidbody2D>();
        rigA.gravityScale = 0;
        rigA.velocity = new Vector2(0,0);
        Rigidbody2D rigB = this.PlayerB.GetComponent<Rigidbody2D>();
        rigB.gravityScale = 0;
        rigB.velocity = new Vector2(0, 0);
        PlayerA Pa = this.PlayerA.GetComponent<PlayerA>();
        Pa.IsFrozen = true;
        PlayerB Pb = this.PlayerB.GetComponent<PlayerB>();
        Pb.IsFrozen = true;
    }

    void Release()
    {
        Rigidbody2D rigA = this.PlayerA.GetComponent<Rigidbody2D>();
        rigA.gravityScale = 3;
        Rigidbody2D rigB = this.PlayerB.GetComponent<Rigidbody2D>();
        rigB.gravityScale = 3;
        PlayerA Pa = this.PlayerA.GetComponent<PlayerA>();
        Pa.IsFrozen = false;
        PlayerB Pb = this.PlayerB.GetComponent<PlayerB>();
        Pb.IsFrozen = false;
    }
}
