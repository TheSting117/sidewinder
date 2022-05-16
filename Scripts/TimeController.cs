using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    //Speed that time will move at
    [SerializeField]
    private float timeMultiplier;
    //Start time when the scene is loaded
    [SerializeField]
    private float startHour;
    //Defines the text field that will display the current time
    [SerializeField]
    private TextMeshProUGUI timeText;
    //Defines the hour that sunrise occurs
    [SerializeField]
    private float sunriseHour;
    //Defines the hour that sunset occurs
    [SerializeField]
    private float sunsetHour;
    //Defines the day and night light tints
    [SerializeField]
    private Color dayLight;
    [SerializeField]
    private Color nightLight;
    //Defines a curve that will make the transition of light seem more natural
    [SerializeField]
    private AnimationCurve lightCurve;
    //Defines how bright the lights can be
    [SerializeField]
    private float maxSunLightIntensity;
    [SerializeField]
    private float maxMoonLightIntensity;
    //Defines the lights that will represent Sun and Moon light
    [SerializeField]
    private Light sunLight;
    [SerializeField]
    private Light moonLight;
    //Defines DateTime and TimeSpan vars that will be defined at the start of the scene
    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    void Start()
    {
        //Sets current time to the startHour
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        //gets the sunrise and sunset times and stores them as timespans
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);

    }

    void Update()
    {
        //Progress the time of day each frame
        UpdateTimeOfDay();
        //Visually progress the time of day each frame
        RotateSun();
        //Update lighting to represent new time
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan riseToSetDur = CalcTimeDiff(sunriseTime, sunsetTime);
            TimeSpan timeSinceRise = CalcTimeDiff(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceRise.TotalMinutes / riseToSetDur.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }

        else
        {
            TimeSpan setToRiseDur = CalcTimeDiff(sunsetTime, sunriseTime);
            TimeSpan timeSinceSet = CalcTimeDiff(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSet.TotalMinutes / setToRiseDur.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);

        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightCurve.Evaluate(dotProduct));

        RenderSettings.ambientLight = Color.Lerp(nightLight, dayLight, lightCurve.Evaluate(dotProduct));
    }
    


    private TimeSpan CalcTimeDiff(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
            
        }
        return difference;
    }
}

