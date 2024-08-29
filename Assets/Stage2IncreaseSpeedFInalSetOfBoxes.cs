using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeedFInalSetOfBoxes : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public GameObject slowCollider;
       // public GameObject boxesToEnable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
              //  boxesToEnable.gameObject.SetActive(true);
                Destroy(this.gameObject);
                Destroy(slowCollider);
                newCarCont.volume6Once = true;
                newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
            }

        }
    }
}
