using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.SpriteRenderer
{
    [Category("DOTween/Tweens/SpriteRenderer")]
    [Name("Create Fade Tween")]
    [Description("Creates a fade tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateFadeTween : ActionTask
    {
        [RequiredField]
        public BBFloat Opacity;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

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