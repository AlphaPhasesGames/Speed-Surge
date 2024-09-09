using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4DetectIfBowlingPinHasFallenOver : MonoBehaviour
    {
        public Stage4PinDetector pinDetect;
        public Rigidbody rb;
        public float fallThresholdAngle = 180f;  // Threshold angle for detecting if the object has fallen over
        private bool hasFallen = false;         // Flag to ensure we only detect the fall once

        void Update()
        {
            // Only check for falling if the object hasn't already fallen
            if (!hasFallen && HasFallenOver())
            {
                pinDetect.amountOfPinsFallen++;
                Debug.Log("The object has fallen over!");
                hasFallen = true;  // Set the flag to true to stop further checks
            }
        }

        bool HasFallenOver()
        {
            // Calculate the angle between the object's up direction and the world up direction
            float angle = Vector3.Angle(transform.up, Vector3.up);
     
            // Check if the angle is greater than the threshold
            return angle > fallThresholdAngle;
        }
    }
}
