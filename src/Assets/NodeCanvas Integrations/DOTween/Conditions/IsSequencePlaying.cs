using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.CInput
{
    [Category("DOTween")]
    [Name("Is Sequence Playing")]
    [Description("Checks to see the if the sequence is playing")]
    [Icon("DOTweenTween")]
    public class IsSequencePlaying : ConditionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        protected override bool OnCheck()
        {
            return Sequence.value.IsPlaying();
        }
    }
}