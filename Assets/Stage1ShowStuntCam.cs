using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1ShowStuntCam : MonoBehaviour
    {

        public Camera stuntCam;
        public Camera vehicleCam;
        public NewCarController carCont;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                vehicleCam.gameObject.SetActive(false);
                stuntCam.gameObject.SetActive(true);
                carCont.skate.mute = true;
            }
        }
    }
}
