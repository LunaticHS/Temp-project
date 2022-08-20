using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 20;
    public float rotareAngle = 180;

    public void SetRotate()
    {

        Quaternion tar = Quaternion.Euler(0, 0, rotareAngle) * transform.rotation;
        StartCoroutine("RotateObj", tar);
    }

    IEnumerator RotateObj(Quaternion tarRotation)
    {
        while (transform.rotation != tarRotation)
        {
            transform.rotation = Quaternion.RotateTowards
                            (transform.rotation, tarRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
