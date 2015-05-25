using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Prepend Tween")]
    [Description("Prepend a tween to a sequence")]
    [Icon("DOTweenTween")]
    public class PrependTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Prepend Tween {0}", Tween);
                descriptionBuilder.AppendFormat("\nTo Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.Prepend(Tween.value);
            EndAction(true);
        }
    }
}