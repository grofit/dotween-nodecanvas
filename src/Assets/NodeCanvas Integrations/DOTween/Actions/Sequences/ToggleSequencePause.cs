using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Toggle Sequence Pause")]
    [Description("Toggles pause for a given Sequence")]
    [Icon("DOTweenTween")]
    public class ToggleSequencePause : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

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