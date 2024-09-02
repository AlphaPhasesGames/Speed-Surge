using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall2Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public Stage3ConeAndRespawnManager coneMan;
        public GameObject wall;
        public GameObject breakableWall;
        public BoxCollider stage2Collider;
        // public bool runOnce;
        public Stage3TextMan textMan;

        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 35)
                {
                  
                    coneMan.step2 = false;
                    coneMan.step3 = true;
                    
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 50;
                    textMan.arrayPos = 13;
                    StartCoroutine(DestroyWall());
                    // runOnce = true;
                }


                if (newCarCont.fwdSpeed < 35)
                {
                    textMan.arrayPos = 11;
                }
            }
           
        }

        public IEnumerator DestroyWall()
        {
            yield return new WaitForSeconds(2f);
            stage2Collider.gameObject.SetActive(false);
            Destroy(breakableWall);
        }
    }
}
