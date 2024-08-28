using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2DecreaseSpeed : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage2TextMan stage2TextManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //stage2TextManager.runOnce3 = true;
                //stage2TextManager.textBools = new bool[22];
                stage2TextManager.arrayPos = 15;
                //newCarCont.isCarActive = false;
                Destroy(this.gameObject);
                newCarCont.maxSpeed = newCarCont.maxSpeed - 5;
            }

        }
    }
}

