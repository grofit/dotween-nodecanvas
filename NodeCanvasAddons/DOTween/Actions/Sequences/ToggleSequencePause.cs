using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Toggle Sequence Pause")]
    [Description("Toggles pause for a given Sequence")]
    [Icon("DOTweenTween")]
    public class ToggleSequencePause : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Toggle {0} Pause", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.TogglePause();
            EndAction(true);
        }
    }
}