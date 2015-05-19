using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Material Vector Tween")]
    [Description("Creates a vector tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateMaterialVectorTween : ActionTask
    {
        [RequiredField]
        public BBVector Value;

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
                descriptionBuilder.AppendFormat("Vector Tween To {0}", Value);
                descriptionBuilder.AppendFormat("\nProperty {0}", PropertyName);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.renderer.material.DOVector(Value.value, PropertyName.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}