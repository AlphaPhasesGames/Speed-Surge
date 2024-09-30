using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4EndFade : MonoBehaviour
    {
        public Animator blackFade;
        public GameObject blackEnable;
        public bool runEnd;
       public void FadeBlack()
        {
            if (runEnd)
            {
                blackEnable.gameObject.SetActive(true);
                blackFade.SetBool("end", true);
                runEnd = false;
            }

        }
    }
}
