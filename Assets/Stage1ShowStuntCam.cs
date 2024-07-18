using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1ShowStuntCam : MonoBehaviour
    {

        public Camera stuntCam;
        public Camera vehicleCam;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                vehicleCam.gameObject.SetActive(false);
                stuntCam.gameObject.SetActive(true);
            }
        }
    }
}
