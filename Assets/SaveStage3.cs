using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class SaveStage3 : MonoBehaviour
    {
        // Start is called before the first frame update
        SSQREMain ssqfeMain;

        // Start is called before the first frame update
        void Start()
        {
            ssqfeMain = FindObjectOfType<SSQREMain>();
            ssqfeMain.SaveStage3();
        }
    }
}
