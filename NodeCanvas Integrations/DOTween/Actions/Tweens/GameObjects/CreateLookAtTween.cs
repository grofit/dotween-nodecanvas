using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Look At Tween")]
    [Description("Creates a look at tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Rigidbody))]
    public class CreateLookAtTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Vector3> LookAt;

        [RequiredField]
        public BBParameter<float> Duration;
        public AxisConstraint AxisConstraint;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("LookAt Tween To {0}", LookAt);
                descriptionBuilder.AppendFormat("\nIn {0} with {1}", Duration, AxisConstraint);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Rigidbody)agent).DOLookAt(LookAt.value, Duration.value, AxisConstraint);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}