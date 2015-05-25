using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Punch Rotation Tween")]
    [Description("Creates a punch rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreatePunchRotationTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Vector3> PunchRotation;

        [RequiredField]
        public BBParameter<float> Duration;

        public BBParameter<int> Vibration = new BBParameter<int> { value = 10 };
        public BBParameter<float> Elasticity = new BBParameter<float> { value = 1.0f };

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Punch Tween To Rotation {0}", PunchRotation);

                descriptionBuilder.AppendFormat("\nWith Vibration {0} and Elasticity {1}", Vibration, Elasticity);

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0} snapping", Duration); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.transform.DOPunchRotation(PunchRotation.value, Duration.value, Vibration.value, Elasticity.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}