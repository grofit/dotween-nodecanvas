using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Set Sequence Easing")]
    [Description("Sets the easing type of the given sequence")]
    [Icon("DOTweenTween")]
    public class SetSequenceEasing: ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        public BBParameter<float> EaseAmplitudeOrOvershoot;

        [RequiredField]
        public BBParameter<float> EasePeriod;


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