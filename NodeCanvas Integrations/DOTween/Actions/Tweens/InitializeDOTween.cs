using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Initialize DO Tween")]
    [Description("Allows you to initialize DO Tween explicitly")]
    [Icon("DOTweenTween")]
    public class InitializeDOTween : ActionTask
    {
        public BBBool RecycleAllByDefault = new BBBool {value = true};
        public BBBool UseSafeMode = new BBBool{value = true};
        public LogBehaviour LogBehaviour;

        public BBInt ExpectedMaximumConcurrentTweens = new BBInt{value = 100 };
        public BBInt ExpectedMaximumConcurrentSequences = new BBInt { value = 10 };


        protected override string info
        {
            get { return "Initialize Tween System"; }
        }

        protected override void OnExecute()
        {
            DG.Tweening.DOTween.Init(RecycleAllByDefault.value, UseSafeMode.value, LogBehaviour)
                .SetCapacity(ExpectedMaximumConcurrentTweens.value, ExpectedMaximumConcurrentSequences.value);
            EndAction(true);
        }
    }
}