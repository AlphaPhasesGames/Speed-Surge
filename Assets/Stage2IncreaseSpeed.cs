using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeed : MonoBehaviour
    {
        public NewCarController newCarCont;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            {
                Destroy(this.gameObject);
                newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
            }

        }
    }
}
