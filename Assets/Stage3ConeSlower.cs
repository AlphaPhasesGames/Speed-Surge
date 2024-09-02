using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3ConeSlower : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public Stage3ConeAndRespawnManager coneMan;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (coneMan.step1)
                {
                    newCarCont.fwdSpeed = newCarCont.fwdSpeed - 10;
                    StartCoroutine(SlowCar());
                }

                if (coneMan.step2)
                {
                    newCarCont.fwdSpeed = newCarCont.fwdSpeed - 20;
                    StartCoroutine(SlowCar1());
                }

                if (coneMan.step3)
                {
                    newCarCont.fwdSpeed = newCarCont.fwdSpeed - 30;
                    StartCoroutine(SlowCar2());
                }

                if (coneMan.step4)
                {
                    newCarCont.fwdSpeed = newCarCont.fwdSpeed - 40;
                    StartCoroutine(SlowCar3());
                }

            }

        }

        public IEnumerator SlowCar()
        {
            newCarCont.maxSpeed = 20;
            yield return new WaitForSeconds(0.5f);
            newCarCont.maxSpeed = 30;
        }

        public IEnumerator SlowCar1()
        {
            newCarCont.maxSpeed = 30;
            yield return new WaitForSeconds(0.5f);
            newCarCont.maxSpeed = 40;
        }

        public IEnumerator SlowCar2()
        {
            newCarCont.maxSpeed = 40;
            yield return new WaitForSeconds(0.5f);
            newCarCont.maxSpeed = 50;
        }

        public IEnumerator SlowCar3()
        {
            newCarCont.maxSpeed = 50;
            yield return new WaitForSeconds(0.5f);
            newCarCont.maxSpeed = 60;
        }
    }
}
