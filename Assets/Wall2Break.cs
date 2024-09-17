using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall2Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public Stage3ConeAndRespawnManager coneMan;
        public GameObject sphereParent;
        public GameObject wall;
        public GameObject breakableWall;
        public BoxCollider stage2Collider;
        public GameObject conesToDelete;
        public GameObject conesToEnable;
        public GameObject wallToEnable;
        public GameObject respawnSection2;
        // public bool runOnce;
        public Stage3TextMan textMan;
        public GameObject wall2Broken;
        public bool submitOnce;
        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed >= 35)
                {
                  
                    coneMan.step2 = false;
                    coneMan.step3 = true;
                    Destroy(conesToDelete);
                    conesToEnable.gameObject.SetActive(true);
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    wallToEnable.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 50;
                    textMan.arrayPos = 13;
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 65, 100);
                        submitOnce = true;
                    }
                 
                    StartCoroutine(DestroyWall());
                    wall2Broken.gameObject.SetActive(true);
                    // runOnce = true;
                }


                if (newCarCont.fwdSpeed < 35)
                {
                    textMan.arrayPos = 11;
                    StartCoroutine(Respawn());
                }
            }
           
        }

        public IEnumerator DestroyWall()
        {
            yield return new WaitForSeconds(2f);
            stage2Collider.gameObject.SetActive(false);
            Destroy(breakableWall);
        }

        public IEnumerator Respawn()
        {
            yield return new WaitForSeconds(5f);
            sphereParent.transform.position = respawnSection2.transform.position;
        }
    }
}
