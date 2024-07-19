using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{


    public class Stage1DisableTextBoxAfterAnswer : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage1TextManager stage1TextMan;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
               // newCarCont.StartStopCar();
                stage1TextMan.textPanal.gameObject.SetActive(false);
                stage1TextMan.arrayPos = 15;
            }

        }

    }
}
