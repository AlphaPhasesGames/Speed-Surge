using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeedNoTextBox : MonoBehaviour
    {
        public NewCarController newCarCont;
        public GameObject slowCollider;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
             
                Destroy(this.gameObject);
                Destroy(slowCollider);
                newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
            }

        }
    }
}
