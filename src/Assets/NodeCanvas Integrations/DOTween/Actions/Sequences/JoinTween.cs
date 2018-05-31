using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Join Tween")]
    [Description("Joins a tween in a given sequence")]
    [Icon("DOTweenTween")]
    public class JoinTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Join Tween {0}", Tween);
                descriptionBuilder.AppendFormat("\nIn Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.Join(Tween.value);
            EndAction(true);
        }
    }
}