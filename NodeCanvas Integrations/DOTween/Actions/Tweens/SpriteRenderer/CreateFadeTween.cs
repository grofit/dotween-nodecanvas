using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens.SpriteRenderer
{
    [Category("DOTween/Tweens/SpriteRenderer")]
    [Name("Create Fade Tween")]
    [Description("Creates a fade tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateFadeTween : ActionTask
    {
        [RequiredField]
        public BBParameter<float> Opacity;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Fade Tween To {0}", Opacity);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((UnityEngine.SpriteRenderer)agent).DOFade(Opacity.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}