using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4RespawnCollider : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public bool runOnce;

        public GameObject carRoation;
        public GameObject carObject;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!runOnce)
                {

                  //  newCarCont.isCarActive = true;
                    newCarCont.maxSpeed = 50;
                    // StartCoroutine(ReserCar());
                    //newCarCont.skate.mute = false;
                    newCarCont.skate.volume = 0;
                    carObject.transform.rotation = carRoation.transform.rotation;
                    // newCarCont.isCarActive = true;
                    StartCoroutine(ReserCar());
                    runOnce = true;
                    Debug.Log("Player Reset");
                }
            }

        }

        public IEnumerator ReserCar()
        {
            yield return new WaitForSeconds(0.5f);
            runOnce = false;
            newCarCont.isCarActive = true;
        }
    }
}
