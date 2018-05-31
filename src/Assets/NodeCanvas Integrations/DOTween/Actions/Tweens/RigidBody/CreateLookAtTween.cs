using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.RigidBody
{
    [Category("DOTween/Tweens/RigidBody")]
    [Name("Create Look At Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateLookAtTween : ActionTask<Rigidbody>
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
            var tweener = agent.DOLookAt(LookAt.value, Duration.value, AxisConstraint);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}