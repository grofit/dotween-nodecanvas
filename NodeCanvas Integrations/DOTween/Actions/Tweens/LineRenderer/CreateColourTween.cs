using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.LineRenderer
{
    [Category("DOTween/Tweens/LineRenderer")]
    [Name("Create Colour Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(UnityEngine.LineRenderer))]
    public class CreateColourTween : ActionTask
    {
        [RequiredField]
        public BBColor StartColour;

        [RequiredField]
        public BBColor EndColour;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Color Tween Start {0}", StartColour);
                descriptionBuilder.AppendFormat("\nTo End {0}", EndColour);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var startColour = new Color2(StartColour.value, StartColour.value);
            var endColour = new Color2(EndColour.value, EndColour.value);
            var tweener = ((UnityEngine.LineRenderer)agent).DOColor(startColour, endColour, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}