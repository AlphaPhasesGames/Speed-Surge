using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class RemoveBrokenBoxes : MonoBehaviour
    {
        public GameObject boxesToDestroy;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Destroy(boxesToDestroy);
            }
        }
    }
}
