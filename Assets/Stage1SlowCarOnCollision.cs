using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1SlowCarOnCollision : MonoBehaviour
    {
        public NewCarController newCarCont;
       // public GameObject slowCollider;
       // public GameObject boxesToEnable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
               // boxesToEnable.gameObject.SetActive(true);
               // newCarCont.volume4Once = true;
               // Destroy(this.gameObject);
              //  Destroy(slowCollider);
                newCarCont.fwdSpeed = newCarCont.fwdSpeed - 20;
            }

        }
    }
}
