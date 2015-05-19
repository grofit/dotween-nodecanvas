using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Lights
{
    [Category("DOTween/Tweens/Lights")]
    [Name("Create Shadow Strength Tween")]
    [Description("Creates an intensity tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Light))]
    public class CreateShadowStrengthTween : ActionTask
    {
        [RequiredField]
        public BBFloat ShadowStrength;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Create Shadow Strength Tween");
                descriptionBuilder.AppendFormat("\nTo {0} In {1}", ShadowStrength, Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Light)agent).DOShadowStrength(ShadowStrength.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}