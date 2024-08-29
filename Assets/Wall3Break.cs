using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall3Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public GameObject wall;
        public GameObject breakableWall; 
        public Stage3TextMan textMan;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 45)
                {
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 60;
                    textMan.arrayPos = 14;
                }


                if (newCarCont.fwdSpeed < 45)
                {
                    textMan.arrayPos = 11;
                }
            }
          
        }
    }
}
