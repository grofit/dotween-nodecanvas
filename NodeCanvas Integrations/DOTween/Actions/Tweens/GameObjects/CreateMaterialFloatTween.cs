using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Material Float Tween")]
    [Description("Creates a float tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreateMaterialFloatTween : ActionTask<Renderer>
    {
        [RequiredField]
        public BBParameter<float> Value;

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
                descriptionBuilder.AppendFormat("Float Tween To {0}", Value);
                descriptionBuilder.AppendFormat("\nProperty {0}", PropertyName);
                descriptionBuilder.AppendFormat("\nIn {0}", Duration);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.material.DOFloat(Value.value, PropertyName.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}