using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioLoudnessMicrophone detector;
    [SerializeField] private float loudnessSens = 100f;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private bool right = true;
    [SerializeField] private float jumpLoudnessThreshold;
    [SerializeField] private float runLoudnessThreshold;
    [SerializeField] private float jumpForce;
    [SerializeField] private float Timer = 3f;
    [SerializeField] private AudioSource audioData;

    AudioSource audioManager;
    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (right == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (right == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSens;

        if (loudness < threshold)
        {
            loudness = 0;

        }

        if (loudness > jumpLoudnessThreshold || Input.GetKeyDown(KeyCode.Space))
        {
            if (right == true)
            {
                print("looking Right");
                rigidbody.AddForce(Vector3.up * 7);
                rigidbody.AddForce(Vector3.right * 3);
            }
            if (right == false)
            {
                print("looking Left");
                rigidbody.AddForce(Vector3.up * 7);
                rigidbody.AddForce(Vector3.left * 3);
            }

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Right")
        {
            print("Duck transform changed left");
            audioData.Play();
            right = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (other.gameObject.tag == "Left")
        {
            print("Duck transform changed right");
            audioData.Play();
            right = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (other.gameObject.tag == "Platform")
        {
            audioData.Play();
        }

    }
}