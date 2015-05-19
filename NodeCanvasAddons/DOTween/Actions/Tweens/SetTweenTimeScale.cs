using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Time Scale")]
    [Description("Sets the global time scale for all tweens")]
    [Icon("DOTweenTween")]
    public class SetTweenTimeScale : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;

        [RequiredField]
        public BBFloat TimeScale;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Setting Time Scale To {0}", TimeScale);
                descriptionBuilder.AppendFormat("\nFor Tween {0}", Tween);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.timeScale = TimeScale.value;
            EndAction(true);
        }
    }
}