using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class BoxObstaclesStage4 : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
        public BoxCollider cubeColliderToDisable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                    newCarCont.maxSpeed -= 5;
                    cubeColliderToDisable.isTrigger = false;
            }

        }
    }
}
