using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success as soon as the event specified by eventName has been received.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=123")]
    [TaskIcon("{SkinColor}HasReceivedEventIcon.png")]
    public class HasReceivedEvent : Conditional
    {
        [Tooltip("The name of the event to receive")]
        public SharedString eventName = "";

        private bool eventReceived = false;

        public override void OnAwake()
        {
            // Let the behavior tree know that we are interested in receiving the event specified
            Owner.RegisterEvent(eventName.Value, ReceivedEvent);
        }

        public override TaskStatus OnUpdate()
        {
            return eventReceived ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            eventReceived = false;
        }

        public void ReceivedEvent()
        {
            eventReceived = true;
        }

        public override void OnBehaviorComplete()
        {
            // Stop receiving the event when the behavior tree is complete
            Owner.UnregisterEvent(eventName.Value, ReceivedEvent);
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values
            eventName = "";
        }
    }
}