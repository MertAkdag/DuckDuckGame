using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

/// <summary>
//  AMINA GOYİM GELMİŞ 0 DEĞER DÖNDERİYOR ŞUNU SABAH Bİ DÜZELT YAW
/// </summary>




/*
    public AudioSource audioSource;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessMicrophone detector;
    public float loudnessSens = 100f;
    public float threshold = 0.1f;
*/
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        int randomleftrigt = Random.Range(1, 3);
        if (randomleftrigt == 1)
        {

            rigidbody.AddForce(Vector3.right * 150f);
            print("sağa gitti amına");

        }
        if (randomleftrigt == 2)
        {
            rigidbody.AddForce(Vector3.left * 150f);
            print("sola gitti amına");

        }
        print(randomleftrigt);
    }

    // Update is called once per frame
    void Update()
    {
       /* float loudness = detector.GetLoudnessFromMicrophone() * loudnessSens;

        if (loudness < threshold)
            loudness = 0;

        rigidbody.AddForce(Vector3.up * loudness);
*/
    }

    void  OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag == "Right")
        {
            print("sağaçarptı");
            rigidbody.AddForce(Vector3.left * 100f);

        }
        if (other.gameObject.tag == "Left")
        {
            print("solagirdiamına");
            rigidbody.AddForce(Vector3.right * 100f);

        }
    }
  
    
    

}
