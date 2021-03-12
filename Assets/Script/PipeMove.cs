using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; 
        Debug.Log("Update was called");
    }
}