using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Play Tween")]
    [Description("Plays a given Sequence")]
    [Icon("DOTweenTween")]
    public class PlaySequence : ActionTask
    {
        [RequiredField] 
        [BlackboardOnly] 
        public BBParameter<Sequence> Sequence;

        public BBParameter<bool> WaitUntilFinished;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Play Sequence {0}", Sequence);

                if (!WaitUntilFinished.isNone && !WaitUntilFinished.isNull && WaitUntilFinished.value)
                {
                    descriptionBuilder.AppendFormat("\nAnd wait until finished");
                }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            if (WaitUntilFinished.value)
            {
                Sequence.value.OnComplete(() => EndAction(true));
            }

            Sequence.value.Play();

            if (!WaitUntilFinished.value)
            {
                EndAction(true);
            }
        }
    }
}