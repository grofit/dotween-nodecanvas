using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Tween Loop Type")]
    [Description("Sets the loop type of the given tween")]
    [Icon("DOTweenTween")]
    public class SetTweenLoopType : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        [RequiredField]
        public BBParameter<int> Loops;

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