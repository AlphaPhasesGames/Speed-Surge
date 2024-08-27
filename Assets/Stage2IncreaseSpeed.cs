using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeed : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage2TextMan stage2TextManager;
        public GameObject slowCollider;
        public GameObject boxesToDestroy;
        public GameObject boxesToEnable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            {
                stage2TextManager.arrayPos = 16;
                Destroy(this.gameObject);
                Destroy(slowCollider);
                Destroy(boxesToDestroy);
                boxesToEnable.gameObject.SetActive(true);
                newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
            }

        }
    }
}
