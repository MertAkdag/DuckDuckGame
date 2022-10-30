using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessMicrophone : MonoBehaviour
{
    public int SampleWindows = 64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }
    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - SampleWindows;

        if (startPosition < 0)
            return 0;
        float[] waweData = new float[SampleWindows];
        clip.GetData(waweData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < SampleWindows; i++)
        {
            totalLoudness += Mathf.Abs(waweData[i]);
        }

        return totalLoudness / SampleWindows;
    }

}