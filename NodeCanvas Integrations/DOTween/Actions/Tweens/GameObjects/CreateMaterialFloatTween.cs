using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Material Float Tween")]
    [Description("Creates a float tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateMaterialFloatTween : ActionTask
    {
        [RequiredField]
        public BBFloat Value;

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
                descriptionBuilder.AppendFormat("Float Tween To {0}", Value);
                descriptionBuilder.AppendFormat("\nProperty {0}", PropertyName);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.renderer.material.DOFloat(Value.value, PropertyName.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}