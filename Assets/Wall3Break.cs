using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall3Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public Stage3ConeAndRespawnManager coneMan;
        public GameObject wall;
        public GameObject breakableWall; 
        public Stage3TextMan textMan;
        public BoxCollider stage3Collider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 45)
                {
                   
                    coneMan.step2 = false;
                    coneMan.step3 = true;
                
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 60;
                    textMan.arrayPos = 14;
                    StartCoroutine(DestroyWall());
                }


                if (newCarCont.fwdSpeed < 45)
                {
                    textMan.arrayPos = 11;
                    textMan.StartCoroutine(textMan.RespawnCar3());
                }
            }
          
        }

        public IEnumerator DestroyWall()
        {
            yield return new WaitForSeconds(2f);
            stage3Collider.gameObject.SetActive(false);
            Destroy(breakableWall);
        }
    }
}
