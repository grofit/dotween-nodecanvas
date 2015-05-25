using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.Materials
{
    [Category("DOTween/Tweens/Materials")]
    [Name("Create Colour Property Tween")]
    [Description("Creates a colour tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateColourPropertyTween : ActionTask
    {
        [RequiredField] 
        public BBMaterial Material;

        [RequiredField]
        public BBColor NewColour;

        [RequiredField]
        public BBString PropertyName;

        [RequiredField]
        public BBFloat Duration;

        [BlackboardOnly]
        public BBTween CreatedTween;

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