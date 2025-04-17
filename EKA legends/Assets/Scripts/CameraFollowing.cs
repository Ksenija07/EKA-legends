using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform targer;
    [SerializeField] private float smoothing = 5;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - targer.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = targer.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
}
