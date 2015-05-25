using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Tween Ease")]
    [Description("Sets the ease type of a given tween")]
    [Icon("DOTweenTween")]
    public class SetTweenEase : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        public Ease EaseType = Ease.Linear;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Set Ease Type {0}", EaseType);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.SetEase(EaseType);
            EndAction(true);
        }
    }
}