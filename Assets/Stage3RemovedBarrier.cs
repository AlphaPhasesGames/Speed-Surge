using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3RemovedBarrier : MonoBehaviour
    {

        public NewCarControllerStage3 newCarCont;
        public GameObject barrier;
        public bool runOnce;
        // Start is called before the first frame update


        private void Update()
        {
            if (!runOnce)
            {
                if(newCarCont.maxSpeed >= 60)
                {
                    barrier.gameObject.SetActive(false);
                    runOnce = true;
                }
            }
        }
    }
}
