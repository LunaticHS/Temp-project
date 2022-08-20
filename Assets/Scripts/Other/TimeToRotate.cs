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
        }
    }

    IEnumerator Rotate(Quaternion tarRotation)
    {
        while (transform.rotation != tarRotation)
        {
            transform.rotation = Quaternion.RotateTowards
                            (transform.rotation, tarRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        onRotateFinish?.Invoke();
    }
    private void SwitchConfiner()
    {
        index = (index + 1) % colliders.Length;
        confiner.m_BoundingShape2D = colliders[index];

    }

}
