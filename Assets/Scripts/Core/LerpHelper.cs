using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1f;
    private Vector3 refVector = Vector3.zero;

    void Update()
    {
        refVector.Set(target.position.x, transform.position.y, transform.position.z);
        Debug.Log(refVector);
        transform.position = Vector3.Lerp(transform.position, refVector, lerpSpeed * Time.deltaTime);
    }
}
