using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2DecreaseSpeed : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage2TextManager;
        public GameObject boxesToEnable;
        public bool boxHItOnce;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!boxHItOnce)
                {
                    //stage2TextManager.runOnce3 = true;

                    stage2TextManager.arrayPos = 15;
                    //newCarCont.isCarActive = false;
                    Destroy(this.gameObject);
                    newCarCont.maxSpeed = newCarCont.maxSpeed - 5;
                    boxesToEnable.gameObject.SetActive(true);
                    boxHItOnce = true;
                }
            }

        }
    }
}

