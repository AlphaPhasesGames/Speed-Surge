using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2RestartTrack : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage1TextMan;
        public bool wrongAnswer;
        public bool runOnce;
        public bool runTwice;

        public GameObject carRoation;
        public GameObject carObject;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!runOnce)
                {

                        newCarCont.isCarActive = true;
                        newCarCont.maxSpeed = 20;
                       // StartCoroutine(ReserCar());
                        //newCarCont.skate.mute = false;
                        newCarCont.skate.volume = 0;
                        carObject.transform.rotation = carRoation.transform.rotation;
                        runOnce = true;                  
                }              
            }

        }

        public IEnumerator ReserCar()
        {
            yield return new WaitForSeconds(0.5f);
            newCarCont.isCarActive = false;
        }
    }
}
