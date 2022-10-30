using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int SampleWindows = 64;
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip){
        int startPosition = clipPosition - SampleWindows;

        if(startPosition<0)
        return 0;
        float[] waweData = new float[SampleWindows];
        clip.GetData(waweData, startPosition);

        float totalLoudness = 0;

        for(int i = 0; i < SampleWindows; i++){
            totalLoudness += MathF.Abs(waweData[i]);
        }

        return totalLoudness / SampleWindows;
    }
    
}