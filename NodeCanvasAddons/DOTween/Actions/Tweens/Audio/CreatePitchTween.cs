using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Audio
{
    [Category("DOTween/Tweens/Audio")]
    [Name("Create Pitch Tween")]
    [Description("Creates a pitch tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(AudioSource))]
    public class CreatePitchTween : ActionTask
    {
        [RequiredField]
        public BBFloat Pitch;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Pitch Tween To {0}", Pitch);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((AudioSource)agent).DOPitch(Pitch.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}