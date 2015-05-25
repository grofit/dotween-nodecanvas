using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Lights
{
    [Category("DOTween/Tweens/Lights")]
    [Name("Create Colour Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Light))]
    public class CreateColourTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Color> NewColour;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();

                if (!NewColour.isNull && !NewColour.isNone)
                { descriptionBuilder.AppendFormat("Color Tween To {0}", NewColour); }

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0}", Duration); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Light)agent).DOColor(NewColour.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}