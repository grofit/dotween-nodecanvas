using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.Audio
{
    [Category("DOTween/Tweens/Audio")]
    [Name("Create Fade Tween")]
    [Description("Creates a fade tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateFadeTween : ActionTask<AudioSource>
    {
        [RequiredField]
        public BBParameter<float> Fade;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

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