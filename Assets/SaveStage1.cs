using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class SaveStage1 : MonoBehaviour
    {

        SSQREMain ssqfeMain;

        private void Awake()
        {
         
          //  
        }
        // Start is called before the first frame update
        void Start()
        {
            ssqfeMain = FindObjectOfType<SSQREMain>();
            ssqfeMain.SaveStage();
        }

        // Update is called once per frame
        void Update()
        {
           
        }
    }
}
