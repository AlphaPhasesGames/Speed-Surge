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
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //stage2TextManager.runOnce3 = true;
                boxesToEnable.gameObject.SetActive(true);
                stage2TextManager.arrayPos = 15;
                //newCarCont.isCarActive = false;
                Destroy(this.gameObject);
                newCarCont.maxSpeed = newCarCont.maxSpeed - 5;
            }

        }
    }
}

