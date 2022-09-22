using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroInput : MonoBehaviour
{

    public float sensitivity = 100f;
    public float loudness = 0f;

    public float jumpLoudnessThreshold;
    public float runLoudnessThreshold;

    public float jumpForce;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public bool right = true;
    AudioSource _audio;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        // _audio.mute = true;

        while (!(Microphone.GetPosition(null) > 0))
        {

        }

        _audio.Play();

        if (right == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (right == true){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void Update()
    {
        loudness = GetAverageVolume() * sensitivity;
        //  Debug.Log(loudness);
        if (loudness > jumpLoudnessThreshold && isGrounded || Input.GetKeyDown(KeyCode.Space))
        {
            if (right == true)
            {
                print("sağa bakıyor amına goyum");
                rb.AddForce(Vector3.up * 7);
                rb.AddForce(Vector3.right * 3);
            }
            if (right == false)
            {
                print("sola bakıyor amına goyum");
                rb.AddForce(Vector3.up * 7);
                rb.AddForce(Vector3.left * 3);
            }
        }

        if (!isGrounded)
            Debug.Log("____ is in the Air!");
    }
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);

    }

    float GetAverageVolume()
    {

        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);

        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }

        return (a / 256f);
    }

    public void OnCollisionEnter(Collision other)
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
