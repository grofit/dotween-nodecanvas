using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Set Sequence Easing")]
    [Description("Sets the easing type of the given sequence")]
    [Icon("DOTweenTween")]
    public class SetSequenceEasing: ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        [RequiredField]
        public BBFloat EaseAmplitudeOrOvershoot;

        [RequiredField]
        public BBFloat EasePeriod;


        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Setting Sequence Easing");
                descriptionBuilder.AppendFormat("\nWith Ease Amplitude {0}", EaseAmplitudeOrOvershoot);
                descriptionBuilder.AppendFormat("\nAnd Ease Period {0}", EasePeriod);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.easeOvershootOrAmplitude = EaseAmplitudeOrOvershoot.value;
            Sequence.value.easePeriod = EasePeriod.value;
            EndAction(true);
        }
    }
}