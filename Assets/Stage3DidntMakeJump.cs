using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3DidntMakeJump : MonoBehaviour
    {
        public Stage3TextMan textMan;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                textMan.RespawnFunction();
            }
        }
    }
}
