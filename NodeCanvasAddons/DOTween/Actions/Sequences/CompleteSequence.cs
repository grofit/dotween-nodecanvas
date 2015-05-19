using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Complete Sequences")]
    [Description("Completes a given sequence")]
    [Icon("DOTweenTween")]
    public class CompleteSequence : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Complete Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.PlayBackwards();
            EndAction(true);
        }
    }
}