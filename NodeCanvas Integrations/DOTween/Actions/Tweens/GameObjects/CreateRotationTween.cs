using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Rotation Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateRotationTween : ActionTask
    {
        public BBParameter<Vector3> DestinationRotation;
        public BBParameter<GameObject> DestinationGameObject;

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

                if (!DestinationRotation.isNull && !DestinationRotation.isNone)
                { descriptionBuilder.AppendFormat("Rotation Tween To {0}", DestinationRotation); }

                if (!DestinationGameObject.isNull && !DestinationGameObject.isNone)
                { descriptionBuilder.AppendFormat("Rotation Tween To {0}", DestinationGameObject); }

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0} with {1}", Duration, RotateMode); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var destination = DestinationGameObject.value ? DestinationGameObject.value.transform.position : DestinationRotation.value;
            var tweener = agent.transform.DORotate(destination, Duration.value, RotateMode);
            tweener.Pause();
            
            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}