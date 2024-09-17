using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
namespace SSGFE.Alpha.Phases.Games
{
    public class Wall1Break : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public Stage3ConeAndRespawnManager coneMan;
        public Stage3TextMan textMan;
        public GameObject wall;
        public GameObject breakableWall;
        public GameObject conesToDelete;
        public GameObject conesToEnable;
        public GameObject WallsToEnable;
        public BoxCollider stage1Collider;
        public bool runOnce;
        public bool submitOnce;
        public GameObject wall1Broken;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (newCarCont.fwdSpeed >= 25)
                {
                   
                    coneMan.step1 = false;
                    coneMan.step2 = true;
                    Destroy(conesToDelete);
                    conesToEnable.gameObject.SetActive(true);
                    WallsToEnable.gameObject.SetActive(true);
                    wall.gameObject.SetActive(false);
                    breakableWall.gameObject.SetActive(true);
                    newCarCont.maxSpeed = 40;
                    textMan.arrayPos = 12;
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 60, 100);
                        submitOnce = true;
                    }
                   
                    wall1Broken.gameObject.SetActive(true);
                    StartCoroutine(DestroyWall());
                }


                if (newCarCont.fwdSpeed < 25)
                {
                    textMan.arrayPos = 11;
                    textMan.StartCoroutine(textMan.RespawnCar());
                }
            }
            
        }

        public IEnumerator DestroyWall()
        {
            yield return new WaitForSeconds(2f);
            
            Destroy(breakableWall);
            stage1Collider.gameObject.SetActive(false);
        }
    }
}
