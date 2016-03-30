/*
 * Used on each Card Object
 * Handles Double Clicks
 * 
 * Code taken directly from: http://answers.unity3d.com/questions/957874/how-to-detect-double-click-in-c.html
 */

using UnityEngine;
using System.Collections.Generic;
using System;

public class ClickManager
{
    public const double MAX_TIME_TO_CLICK = 0.5;
    public const double MIN_TIME_TO_CLICK = 0.05;
    public bool IsDebug { get; set; }
    private TimeSpan maxDuration = TimeSpan.FromSeconds(MAX_TIME_TO_CLICK);
    private TimeSpan minDuration = TimeSpan.FromSeconds(MIN_TIME_TO_CLICK);

    private System.Diagnostics.Stopwatch timer;
    private bool ClickedOnce = false;

    public bool DoubleClick()
    {
        if (!ClickedOnce)
        {
            timer = System.Diagnostics.Stopwatch.StartNew();
            ClickedOnce = true;
        }
        if (ClickedOnce)
        {
            if (timer.Elapsed > minDuration && timer.Elapsed < maxDuration)
            {
                if (IsDebug)
                    Debug.Log("Double Click");
                ClickedOnce = false;
                return true;
            }
            else if (timer.Elapsed > maxDuration)
            {
                ClickedOnce = false;
                if (IsDebug)
                    Debug.Log("Time out");
                return false;
            }
        }
        return false;
    }
}