using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Create Sequences")]
    [Description("Creates a sequence for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateSequence : ActionTask
    {
        [BlackboardOnly]
        public BBSequence CreatedSequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Creating Sequence {0}", CreatedSequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var sequence = DG.Tweening.DOTween.Sequence();
            CreatedSequence.value = sequence;
            sequence.Pause();

            EndAction(true);
        }
    }
}