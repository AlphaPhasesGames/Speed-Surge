using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall2Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public GameObject wall;
        public GameObject breakableWall;
       // public bool runOnce;
        public Stage3TextMan textMan;

        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 35)
                {
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 50;
                    textMan.arrayPos = 13;
                   // runOnce = true;
                }


                if (newCarCont.fwdSpeed < 35)
                {
                    textMan.arrayPos = 11;
                }
            }
           
        }
    }
}
