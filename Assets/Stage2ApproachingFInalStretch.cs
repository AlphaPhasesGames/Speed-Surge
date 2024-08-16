using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2ApproachingFInalStretch : MonoBehaviour
    {

        public Stage2TextMan stage2TextManager;
        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {

              
                    stage2TextManager.arrayPos = 17;
              

            }

        }
    }
}
