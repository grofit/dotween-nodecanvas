using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Pause Sequence")]
    [Description("Pauses a given Sequence")]
    [Icon("DOTweenTween")]
    public class PauseSequence : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Pause Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.Pause();
            EndAction(true);
        }
    }
}