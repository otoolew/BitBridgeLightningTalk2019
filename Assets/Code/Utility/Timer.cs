using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Timer
{
    private float timerCount;
    public float currentTime;
    public float lastTriggerTime;
    public bool finished;
    public Timer(float countTime)
    {
        timerCount = countTime;
        currentTime = 0;
        finished = false;
    }

    public void Tick(float deltaTime)
    {
        currentTime += deltaTime;
        if (NormalizedProgress < 1f)
            finished = false;
        else
            finished = true;
    }

    public void ResetTimer()
    {
        currentTime = 0;
        finished = false;
    }
    public float NormalizedProgress
    {
        get { return Mathf.Clamp(currentTime / timerCount, 0f, 1f); }
    }
}
