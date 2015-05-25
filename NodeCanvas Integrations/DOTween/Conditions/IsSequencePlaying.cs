using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.CInput
{
    [Category("DOTween")]
    [Name("Is Sequnece Playing")]
    [Description("Checks to see the if the sequence is playing")]
    [Icon("DOTweenTween")]
    public class IsSequencePlaying : ConditionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        protected override bool OnCheck()
        {
            return Sequence.value.IsPlaying();
        }
    }
}