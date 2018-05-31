using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.RigidBody
{
    [Category("DOTween/Tweens/RigidBody")]
    [Name("Create Rotation Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateRotationTween : ActionTask<Rigidbody>
    {
        [RequiredField]
        public BBParameter<Vector3> Rotation;

        [RequiredField]
        public BBParameter<float> Duration;
        public RotateMode RotateMode;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Rotation Tween To {0}", Rotation);
                descriptionBuilder.AppendFormat("\nIn {0} with {1}", Duration, RotateMode);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.DORotate(Rotation.value, Duration.value, RotateMode);
            tweener.Pause();
            
            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}