using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    public Animator animator;
    private bool isOpen;
    private Vector3 startPosition;
    
    // Update is called once per frame
    void Update()
    {
        isOpen = animator.GetBool("isOpen");
        
        if (isOpen)
        {
            transform.position = startPosition;
        }
    }

    public void Open()
    {
        startPosition = transform.position;
    }
}
