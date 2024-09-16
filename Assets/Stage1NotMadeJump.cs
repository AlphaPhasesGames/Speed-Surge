using System;
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
               // textMan.restrictionBool2 = true;
                textMan.hasScrolled = false;
                //Array.Fill(textMan.textBools, false);

                textMan.textBools = new bool[21]; // All elements are automatically set to false
                                                                  //  textMan.textBools[13] = false;
                                                                  //  textMan.textBools[14] = false;
                                                                  //  textMan.textBools[12] = false;
                                                                  //   textMan.textBools[11] = false;
                                                                  //  textMan.textBools[19] = false;
                                                                  //   textMan.textBools[18] = false;
               textMan.ResetCarPosition();
                                                                  // textMan.arrayPos = 17;
                vehicleCam.gameObject.SetActive(true);
                    stuntCam.gameObject.SetActive(false);
                
            }
        }
    }
}
