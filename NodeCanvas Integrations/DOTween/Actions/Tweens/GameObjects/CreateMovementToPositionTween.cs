using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Movement To Position Tween")]
    [Description("Creates a movement tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateMovementToPositionTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Vector3> Destination;

        [RequiredField]
        public BBParameter<float> Duration;
        public BBParameter<bool> UseSnapping;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Movement Tween To {0}", Destination);
                
                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0} {1} snapping", Duration, UseSnapping.value ? "with" : "without"); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.transform.DOMove(Destination.value, Duration.value, UseSnapping.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}