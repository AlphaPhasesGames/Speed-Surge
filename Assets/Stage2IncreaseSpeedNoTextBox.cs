using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeedNoTextBox : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public GameObject slowCollider;
        public GameObject boxesToEnable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                boxesToEnable.gameObject.SetActive(true);
                newCarCont.volume2Once = true;
                Destroy(this.gameObject);
                Destroy(slowCollider);
                newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
            }

        }
    }
}
