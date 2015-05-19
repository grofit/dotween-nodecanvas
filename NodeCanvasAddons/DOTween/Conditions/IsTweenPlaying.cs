using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.CInput
{
    [Category("DOTween")]
    [Name("Is Tween Playing")]
    [Description("Checks to see the if the tween is playing")]
    [Icon("DOTweenTween")]
    public class IsTweenPlaying : ConditionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;

        protected override bool OnCheck()
        {
            return Tween.value.IsPlaying();
        }
    }
}