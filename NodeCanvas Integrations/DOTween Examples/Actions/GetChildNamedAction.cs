using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.CInput.Examples
{
    [Category("GameObject")]
    [Name("Get Child Named")]
    public class GetChildNamedAction : ActionTask
    {
        [RequiredField]
        public BBParameter<string> ChildName;

        [BlackboardOnly]
        public BBParameter<GameObject> MatchingObject = new BBParameter<GameObject>();

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