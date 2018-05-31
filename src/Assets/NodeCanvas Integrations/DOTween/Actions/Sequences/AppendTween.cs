using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Append Tween")]
    [Description("Append a tween to a sequence")]
    [Icon("DOTweenTween")]
    public class AppendTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField] 
        public BBParameter<Tween> Tween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Append Tween {0}", Tween);
                descriptionBuilder.AppendFormat("\nTo Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.Append(Tween.value);
            EndAction(true);
        }
    }
}