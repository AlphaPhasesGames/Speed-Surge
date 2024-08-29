using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3FinishLine : MonoBehaviour
    {
        public NewCarController newCarCont;
        //public GameObject wall;
        //public GameObject breakableWall;
        public Stage3TextMan textMan;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                    newCarCont.isCarActive = false;
                    textMan.arrayPos = 15;


               
            }

        }
    }
}
