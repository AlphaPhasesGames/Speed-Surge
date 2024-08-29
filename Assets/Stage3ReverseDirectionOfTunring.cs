using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3ReverseDirectionOfTunring : MonoBehaviour
    {
        public NewCarControllerStage3 carCont;
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                carCont.carTurningReverse = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                carCont.carTurningReverse = false;
            }
        }
    }
}
