using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.CInput
{
    [Category("DOTween")]
    [Name("Is Tween Playing")]
    [Description("Checks to see the if the tween is playing")]
    [Icon("DOTweenTween")]
    public class IsTweenPlaying : ConditionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        protected override bool OnCheck()
        {
            return Tween.value.IsPlaying();
        }
    }
}