using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1StopShowIngStuntCam : MonoBehaviour
    {

        public Camera stuntCam;
        public Camera vehicleCam;
        public NewCarController carCont;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                vehicleCam.gameObject.SetActive(true);
                stuntCam.gameObject.SetActive(false);
                carCont.skate.mute = false;
                LOLSDK.Instance.SubmitProgress(0, 15, 100);
            }
        }
    }
}
