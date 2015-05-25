using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Insert Tween")]
    [Description("Insert a tween at a given time position in a sequence")]
    [Icon("DOTweenTween")]
    public class InsertTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        [RequiredField] 
        public BBParameter<float> TimePosition;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Insert Tween {0} At {1}", Tween, TimePosition);
                descriptionBuilder.AppendFormat("\nTo Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.Insert(TimePosition.value, Tween.value);
            EndAction(true);
        }
    }
}