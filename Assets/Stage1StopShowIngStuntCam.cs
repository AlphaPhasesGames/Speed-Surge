using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1StopShowIngStuntCam : MonoBehaviour
    {

        public Camera stuntCam;
        public Camera vehicleCam;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                vehicleCam.gameObject.SetActive(true);
                stuntCam.gameObject.SetActive(false);
            }
        }
    }
}
