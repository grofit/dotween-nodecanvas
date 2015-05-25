using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Materials
{
    [Category("DOTween/Tweens/Materials")]
    [Name("Create Colour Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateColourTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Material> Material;

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
            var tweener = Material.value.DOColor(NewColour.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}