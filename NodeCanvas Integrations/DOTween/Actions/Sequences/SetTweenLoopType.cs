using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Set Sequence Loop Type")]
    [Description("Sets the loop type of the given sequence")]
    [Icon("DOTweenTween")]
    public class SetSequenceLoopType : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        [RequiredField]
        public BBInt Loops;

        [RequiredField]
        public LoopType LoopType;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Looping {0} times", Loops);
                descriptionBuilder.AppendFormat("\nWith Type {0}", LoopType);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.SetLoops(Loops.value, LoopType);
            EndAction(true);
        }
    }
}