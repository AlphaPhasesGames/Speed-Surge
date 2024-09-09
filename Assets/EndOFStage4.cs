using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class EndOFStage4 : MonoBehaviour
    {
        public Stage4TextMan stage4TextMan;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                stage4TextMan.arrayPos = 12;
            }
        }
    }
}
