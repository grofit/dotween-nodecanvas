using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Movement To Position Tween")]
    [Description("Creates a movement tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateMovementToPositionTween : ActionTask
    {
        [RequiredField]
        public BBVector Destination;

        [RequiredField]
        public BBFloat Duration;
        public BBBool UseSnapping;

        [BlackboardOnly] 
        public BBTween CreatedTween;

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