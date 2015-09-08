using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Sends an event to the behavior tree, returns success after sending the event.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=121")]
    [TaskIcon("{SkinColor}SendEventIcon.png")]
    public class SendEvent : Action
    {
        [Tooltip("The GameObject of the behavior tree that should have the event sent to it. If null use the current behavior")]
        public SharedGameObject targetGameObject;
        [Tooltip("The event to send")]
        public SharedString eventName;

        private BehaviorTree behaviorTree;

        public override void OnStart()
        {
            behaviorTree = GetDefaultGameObject(targetGameObject.Value).GetComponent<BehaviorTree>();
        }

        public override TaskStatus OnUpdate()
        {
            // Send the event and return success
            behaviorTree.SendEvent(eventName.Value);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values
            targetGameObject = null;
            eventName = "";
        }
    }
}