using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Append Interval")]
    [Description("Append an interval to a sequence")]
    [Icon("DOTweenTween")]
    public class AppendInterval : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        public BBParameter<float> Interval;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Append Interval {0}", Interval);
                descriptionBuilder.AppendFormat("\nTo Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.AppendInterval(Interval.value);
            EndAction(true);
        }
    }
}