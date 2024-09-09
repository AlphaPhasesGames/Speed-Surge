using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class TestScript : MonoBehaviour
    {
        public Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                rb.AddForce(-transform.right * 50000f);
            }
        }
    }
}
