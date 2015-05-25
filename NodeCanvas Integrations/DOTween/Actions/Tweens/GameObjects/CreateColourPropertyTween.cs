using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Colour Property Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateColourPropertyTween : ActionTask<Renderer>
    {
        [RequiredField]
        public BBParameter<Color> NewColour;

        [RequiredField]
        public BBParameter<string> PropertyName;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();

                descriptionBuilder.AppendFormat("Color Tween To {0}", NewColour);
                descriptionBuilder.AppendFormat("\nFor Property {0}", PropertyName);

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0}", Duration); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.material.DOColor(NewColour.value, PropertyName.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}