using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2ResetNotFastEnough : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage2TextManager;

        public GameObject sphereParent;
        public GameObject resetPosition;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(newCarCont.maxSpeed <= 15)
                {
                    //stage2TextManager.ResetCarArrayMove();
                    stage2TextManager.ResetArrays();
                   stage2TextManager.restrictionBool2 = false;
                    stage2TextManager.arrayPos = 15;
                }
            }
        }
    }
}
