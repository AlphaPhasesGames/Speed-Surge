using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SSGFE.Alpha.Phases.Games
{
    public class SpeedController : MonoBehaviour
    {

        public TextMeshProUGUI speed;
        public NewCarController newCC;
        // Start is called before the first frame update
     
        // Update is called once per frame
        void Update()
        {
            // int mySpeed = speed.text as int;
            speed.text = newCC.fwdSpeed.ToString("0");
        }
    }
}
