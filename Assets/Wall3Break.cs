using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall3Break : MonoBehaviour
    {
        public NewCarController newCarCont;
        public GameObject wall;
        public GameObject breakableWall;
        public bool runOnce;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 45)
                {
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 60;
                    runOnce = true;
                }
            }
          
        }
    }
}
