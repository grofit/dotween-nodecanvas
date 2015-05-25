using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Lights
{
    [Category("DOTween/Tweens/Lights")]
    [Name("Create Intensity Tween")]
    [Description("Creates an intensity tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Light))]
    public class CreateIntensityTween : ActionTask
    {
        [RequiredField]
        public BBFloat Intensity;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Color Tween To {0}", Intensity);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Light)agent).DOIntensity(Intensity.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}