using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2FinalBoxes : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage2TextMan stage2TextManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                if(newCarCont.maxSpeed >= 40)
                {
                    stage2TextManager.arrayPos = 18;
                    //newCarCont.isCarActive = false;
                    Destroy(this.gameObject);
                }

                if (newCarCont.maxSpeed < 40 )
                {
                    stage2TextManager.arrayPos = 20;
                    //newCarCont.isCarActive = false;
                    Destroy(this.gameObject);
                }

            }

        }
    }
}
