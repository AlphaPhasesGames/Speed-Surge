using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3ConeAndRespawnManager : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        //  public Stage2TextMan stage2TextManager;
        public bool step1;
        public bool step2;
        public bool step3;
        public bool step4;


        private void Awake()
        {
            step1 = true;
        }
 
    }
}
