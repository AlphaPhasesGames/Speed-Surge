using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1NotMadeJump : MonoBehaviour
    {

        public Stage1TextManager textMan;
        public Camera stuntCam;
        public Camera vehicleCam;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                textMan.restrictionBool2 = true;
                textMan.hasScrolled = false;
              //  textMan.arrayPos = 19;
                    vehicleCam.gameObject.SetActive(true);
                    stuntCam.gameObject.SetActive(false);
                
            }
        }
    }
}
