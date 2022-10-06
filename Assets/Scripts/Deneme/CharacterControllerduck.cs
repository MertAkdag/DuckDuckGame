using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerduck : MonoBehaviour
{

    /// <summary>
    //  AMINA GOYİM GELMİŞ 0 DEĞER DÖNDERİYOR ŞUNU SABAH Bİ DÜZELT YAW
    /// </summary>




    public AudioSource audioSource;
    public AudioLoudnessMicrophone detector;
    public float loudnessSens = 100f;
    public float threshold = 0.1f;
    public bool right = true;
    public float jumpLoudnessThreshold;
    public float runLoudnessThreshold;
    public float jumpForce;


    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        /*
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
        */


        if (right == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (right == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSens;

        if (loudness < threshold)
            loudness = 0;

        if (loudness > jumpLoudnessThreshold || Input.GetKeyDown(KeyCode.Space))
        {
            if (right == true)
            {
                print("sağa bakıyor amına goyum");
                rigidbody.AddForce(Vector3.up * 7);
                rigidbody.AddForce(Vector3.right * 3);
            }
            if (right == false)
            {
                print("sola bakıyor amına goyum");
                rigidbody.AddForce(Vector3.up * 7);
                rigidbody.AddForce(Vector3.left * 3);
            }

        }

        //rigidbody.AddForce(Vector3.up * loudness);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Right")
        {
            print("amınakoyim bu ne ya");

            right = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (other.gameObject.tag == "Left")
        {
            right = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }




}