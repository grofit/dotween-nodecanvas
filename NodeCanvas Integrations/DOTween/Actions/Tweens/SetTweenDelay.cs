using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Tween Delay")]
    [Description("Sets the delay of a given tween")]
    [Icon("DOTweenTween")]
    public class SetTweenDelay : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        [RequiredField]
        public BBParameter<float> Delay;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Set Delay {0}", Delay);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.SetDelay(Delay.value);
            EndAction(true);
        }
    }
}