using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4ReduceSpeed : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
              
                newCarCont.fwdSpeed = newCarCont.fwdSpeed - 40;
            }

        }
    }
}
