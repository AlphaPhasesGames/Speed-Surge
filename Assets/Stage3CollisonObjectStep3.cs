using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3CollisonObjectStep3 : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        //  public Stage2TextMan stage2TextManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                newCarCont.fwdSpeed = newCarCont.fwdSpeed - 20;
                StartCoroutine(SlowCar());
            }

        }

        public IEnumerator SlowCar()
        {
            newCarCont.maxSpeed = 40;
            yield return new WaitForSeconds(0.5f);
            newCarCont.maxSpeed = 50;
        }
    }
}
