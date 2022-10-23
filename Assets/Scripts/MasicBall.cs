using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicBall : MonoBehaviour
{

    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
