using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDenem : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb2d;
    [SerializeField] private float force;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            tapTap();
        }
        
        if(Input.GetKeyDown(KeyCode.H))
        {
            tapTap();
        }
    }

    public void tapTap()
    {
        rb2d.AddForce(Vector2.up * force);
    }
}
