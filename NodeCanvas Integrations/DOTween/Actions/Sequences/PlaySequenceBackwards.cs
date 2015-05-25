using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Play Sequence Backwards")]
    [Description("Plays a given sequence Backwards")]
    [Icon("DOTweenTween")]
    public class PlaySequenceBackwards : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Play {0} Backwards", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.PlayBackwards();
            EndAction(true);
        }
    }
}