using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    public GameObject gameObject;
    private bool active;
    public bool AlreadyEntered;
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (AlreadyEntered)
        {
            gameObject.SetActive(false);
        }
    }

    public void DeActivate()
    {
        AlreadyEntered = true;
    }
}
