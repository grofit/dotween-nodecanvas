using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Audio
{
    [Category("DOTween/Tweens/Audio")]
    [Name("Create Fade Tween")]
    [Description("Creates a fade tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(AudioSource))]
    public class CreateFadeTween : ActionTask
    {
        [RequiredField]
        public BBFloat Fade;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Fade Tween To {0}", Fade);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((AudioSource)agent).DOFade(Fade.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}