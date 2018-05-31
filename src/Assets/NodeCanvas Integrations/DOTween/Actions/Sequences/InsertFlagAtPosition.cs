using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Insert Flag At Position")]
    [Description("Inserts a callback in the sequence which will set a given flag to true when it occurs")]
    [Icon("DOTweenTween")]
    public class InsertFlagAtPosition : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Sequence> Sequence;

        [RequiredField]
        public BBParameter<bool> FlagVariable;

        [RequiredField]
        public BBParameter<float> TimePosition;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Insert Callback Flag {0} At {1}", FlagVariable, TimePosition);
                descriptionBuilder.AppendFormat("\nTo Sequence {0}", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.InsertCallback(TimePosition.value, () => { FlagVariable.value = true; });
            EndAction(true);
        }
    }
}