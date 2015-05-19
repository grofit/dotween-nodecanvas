using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Look At Game Objec Tween")]
    [Description("Creates a look at tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Rigidbody))]
    public class CreateLookAtGameObjectTween : ActionTask
    {
        [RequiredField]
        public BBGameObject LookAtObject;

        [RequiredField]
        public BBFloat Duration;
        public AxisConstraint AxisConstraint;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("LookAt Tween To {0}", LookAtObject);
                descriptionBuilder.AppendFormat("\nIn {0} with {1}", Duration, AxisConstraint);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Rigidbody)agent).DOLookAt(LookAtObject.value.transform.position, Duration.value, AxisConstraint);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}