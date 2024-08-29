using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall1Break : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage3TextMan textMan;
        public GameObject wall;
        public GameObject breakableWall;
        public bool runOnce;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 25)
                {
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 40;
                    textMan.arrayPos = 12;
                    runOnce = true;
                }


                if (newCarCont.fwdSpeed < 25)
                {
                    textMan.arrayPos = 11;
                }
            }
            
        }
    }
}
