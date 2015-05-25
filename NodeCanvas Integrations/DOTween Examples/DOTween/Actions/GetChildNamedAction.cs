using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.CInput.Examples
{
    [Category("GameObject")]
    [Name("Get Child Named")]
    public class GetChildNamedAction : ActionTask
    {
        [RequiredField]
        public BBString ChildName;

        [BlackboardOnly]
        public BBGameObject MatchingObject = new BBGameObject();

        protected override string info
        {
            get { return string.Format("Store child <b>{0}</b> into {1}", ChildName.value, MatchingObject); }
        }

        protected override void OnExecute()
        {
            var matchingChild = agent.transform.FindChild(ChildName.value);
            if (matchingChild)
            {
                MatchingObject.value = matchingChild.gameObject;
                EndAction(true);
            }
            EndAction(false);
        }
    }
}