using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcomplated : MonoBehaviour
{
    GameObject gamoverpanel;

    void OnCollisionEnter(Collision other)
    {
        gamoverpanel.SetActive(true);
    }
}
