using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens.TrailRenderer
{
    [Category("DOTween/Tweens/TrailRenderer")]
    [Name("Create Resize Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(UnityEngine.TrailRenderer))]
    public class CreateResizeTween : ActionTask
    {
        [RequiredField]
        public BBParameter<float> StartSize;

        [RequiredField]
        public BBParameter<float> EndSize;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Resize Tween Start {0}", StartSize);
                descriptionBuilder.AppendFormat("\nTo End {0}", EndSize);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((UnityEngine.TrailRenderer)agent).DOResize(StartSize.value, EndSize.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}