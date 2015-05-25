using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.SpriteRenderer
{
    [Category("DOTween/Tweens/SpriteRenderer")]
    [Name("Create Colour Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(UnityEngine.SpriteRenderer))]
    public class CreateColourTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Color> StartColour;

        [RequiredField]
        public BBParameter<float> Duration;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Color Tween Start {0}", StartColour);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((UnityEngine.SpriteRenderer)agent).DOColor(StartColour.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}