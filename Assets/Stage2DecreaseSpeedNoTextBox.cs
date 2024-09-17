using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2DecreaseSpeedNoTextBox : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public GameObject boxesToEnable;
        //  public GameObject slowCollider;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                Destroy(this.gameObject);
               // Destroy(slowCollider);
                newCarCont.maxSpeed = newCarCont.maxSpeed - 5;
                boxesToEnable.gameObject.SetActive(true);
            }

        }
    }
}
