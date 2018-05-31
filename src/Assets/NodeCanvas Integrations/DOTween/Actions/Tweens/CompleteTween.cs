using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Complete Tween")]
    [Description("Completes the given tween")]
    [Icon("DOTweenTween")]
    public class CompleteTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;
        
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