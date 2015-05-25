using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Initialize DO Tween")]
    [Description("Allows you to initialize DO Tween explicitly")]
    [Icon("DOTweenTween")]
    public class InitializeDOTween : ActionTask
    {
        public BBParameter<bool> RecycleAllByDefault = new BBParameter<bool> {value = true};
        public BBParameter<bool> UseSafeMode = new BBParameter<bool>{value = true};
        public LogBehaviour LogBehaviour;

        public BBParameter<int> ExpectedMaximumConcurrentTweens = new BBParameter<int>{value = 100 };
        public BBParameter<int> ExpectedMaximumConcurrentSequences = new BBParameter<int> { value = 10 };


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