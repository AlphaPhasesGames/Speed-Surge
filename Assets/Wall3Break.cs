using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
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
        public GameObject sphereParent;
        public GameObject respawnSection2;
        public GameObject wall3Broken;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed > 45)
                {
                   
                    coneMan.step2 = false;
                    coneMan.step3 = true;
                    LOLSDK.Instance.SubmitProgress(0, 70, 100);
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 60;
                    textMan.arrayPos = 14;
                    StartCoroutine(DestroyWall());
                    wall3Broken.gameObject.SetActive(true);
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

        public IEnumerator Respawn()
        {
            yield return new WaitForSeconds(5f);
            sphereParent.transform.position = respawnSection2.transform.position;
        }
    }
}
