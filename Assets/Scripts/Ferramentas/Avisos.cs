using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisos : MonoBehaviour
{
    public GameObject Edgar;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Edgar.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Edgar.transform.position + offset;
    }
}
