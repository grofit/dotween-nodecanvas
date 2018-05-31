using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens.TrailRenderer
{
    [Category("DOTween/Tweens/TrailRenderer")]
    [Name("Create Time Tween")]
    [Description("Creates a time tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateTimeTween : ActionTask<UnityEngine.TrailRenderer>
    {
        [RequiredField]
        public BBParameter<float> EndValue;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Time Tween {0}", EndValue);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.DOTime(EndValue.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}