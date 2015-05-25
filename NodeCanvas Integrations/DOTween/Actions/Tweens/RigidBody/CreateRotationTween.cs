using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.RigidBody
{
    [Category("DOTween/Tweens/RigidBody")]
    [Name("Create Rotation Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Rigidbody))]
    public class CreateRotationTween : ActionTask
    {
        [RequiredField]
        public BBVector Rotation;

        [RequiredField]
        public BBFloat Duration;
        public RotateMode RotateMode;

        [BlackboardOnly] 
        public BBTween CreatedTween;

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