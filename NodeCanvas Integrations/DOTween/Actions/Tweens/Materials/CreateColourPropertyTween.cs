using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.Materials
{
    [Category("DOTween/Tweens/Materials")]
    [Name("Create Colour Property Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateColourPropertyTween : ActionTask
    {
        [RequiredField] 
        public BBParameter<Material> Material;

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
            var tweener = Material.value.DOColor(NewColour.value, PropertyName.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}