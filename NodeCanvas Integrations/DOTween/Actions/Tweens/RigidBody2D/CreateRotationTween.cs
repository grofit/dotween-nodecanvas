using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.RigidBody2D
{
    [Category("DOTween/Tweens/RigidBody2D")]
    [Name("Create Rotation Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Rigidbody2D))]
    public class CreateRotationTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Vector2> Rotation;

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
            var tweener = ((Rigidbody)agent).DORotate(Rotation.value, Duration.value, RotateMode);
            tweener.Pause();
            
            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}