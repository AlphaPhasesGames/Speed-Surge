using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2IncreaseSpeed : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage2TextManager;
        public GameObject slowCollider;
        public bool boxHItOnce;
        public GameObject boxesToEnable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            {
                if (!boxHItOnce) 
                {
                    stage2TextManager.arrayPos = 16;
                    newCarCont.volume1Once = true;
                    Destroy(this.gameObject);
                    Destroy(slowCollider);

                    boxesToEnable.gameObject.SetActive(true);
                    newCarCont.maxSpeed = newCarCont.maxSpeed + 5;
                    //StartCoroutine(RemoveBoxes());
                    //  Destroy(boxesToDestroy);
                    boxHItOnce = true;
                }

            }

        }

     
    }
}
