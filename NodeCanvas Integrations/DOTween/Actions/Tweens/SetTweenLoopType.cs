using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Tween Loop Type")]
    [Description("Sets the loop type of the given tween")]
    [Icon("DOTweenTween")]
    public class SetTweenLoopType : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;

        [RequiredField]
        public BBInt Loops;

        [RequiredField]
        public LoopType LoopType;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Looping {0} times with Type {1}", Loops, LoopType);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.SetLoops(Loops.value, LoopType);
            EndAction(true);
        }
    }
}