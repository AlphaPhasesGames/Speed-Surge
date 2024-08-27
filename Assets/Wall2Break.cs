using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall2Break : MonoBehaviour
    {
        public NewCarController newCarCont;
        public GameObject wall;
        public GameObject breakableWall;
        public bool runOnce;


        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 35)
                {
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 50;
                    runOnce = true;
                }
            }
           
        }
    }
}
