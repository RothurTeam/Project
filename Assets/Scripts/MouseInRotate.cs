using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInRotate : MonoBehaviour
{
    public float offset;
    //public GameObject pl;
    void Start()
    {
        //pl = GetComponent<PlayerMove>();
    }
    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);

        Vector3 localScale = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }

        transform.localScale = localScale;
    }
}
