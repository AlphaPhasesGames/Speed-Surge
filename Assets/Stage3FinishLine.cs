using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3FinishLine : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        //public GameObject wall;
        //public GameObject breakableWall;
        public Stage3TextMan textMan;
        public AudioSource carSounds;
        public AudioSource wheelSounds;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                    newCarCont.isCarActive = false;
                    textMan.arrayPos = 15;
                    wheelSounds.Stop();
                    carSounds.Stop();


            }

        }
    }
}
