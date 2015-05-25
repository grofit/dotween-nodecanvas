using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Complete Tween")]
    [Description("Completes the given tween")]
    [Icon("DOTweenTween")]
    public class CompleteTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;
        
        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Completing Tween {0}", Tween);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.Complete();
            EndAction(true);
        }
    }
}