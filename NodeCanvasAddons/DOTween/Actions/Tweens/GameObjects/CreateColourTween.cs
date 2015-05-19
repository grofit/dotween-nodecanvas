using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Colour Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateColourTween : ActionTask
    {
        [RequiredField]
        public BBColor NewColour;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();

                if (!NewColour.isNull && !NewColour.isNone)
                { descriptionBuilder.AppendFormat("Color Tween To {0}", NewColour); }

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0}", Duration); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.renderer.material.DOColor(NewColour.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}