#if !(UNITY_4_3 || UNITY_4_4)
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody2D
{
    [TaskCategory("Basic/Rigidbody2D")]
    [TaskDescription("Stores the position of the Rigidbody2D. Returns Success.")]
    public class GetPosition : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The velocity of the Rigidbody2D")]
        [RequiredField]
        public SharedVector2 storeValue;

        private Rigidbody2D rigidbody2D;
        private GameObject prevGameObject;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                rigidbody2D = currentGameObject.GetComponent<Rigidbody2D>();
                prevGameObject = currentGameObject;
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (rigidbody2D == null) {
                Debug.LogWarning("Rigidbody2D is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = rigidbody2D.position;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
             targetGameObject = null;
             storeValue = Vector2.zero;
        }
    }
}
#endif