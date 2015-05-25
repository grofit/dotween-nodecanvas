using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Tween Delay")]
    [Description("Sets the end point of a given tween to be relative (start + end) or absolute (end)")]
    [Icon("DOTweenTween")]
    public class SetTweenRelativity : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        [RequiredField]
        public BBParameter<bool> IsRelative;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Set Relativity to {0}", IsRelative);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.SetRelative(IsRelative.value);
            EndAction(true);
        }
    }
}