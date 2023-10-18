using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float dropToYPos;
    private float speed = 0.3f;
    //toc do roi
    private void Start()
    {

        Destroy(gameObject, Random.Range(9f, 15f));
        //thoi gian destroy anh nang
    }
    private void Update()
    {
        if (transform.position.y >= dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);

    }
}
