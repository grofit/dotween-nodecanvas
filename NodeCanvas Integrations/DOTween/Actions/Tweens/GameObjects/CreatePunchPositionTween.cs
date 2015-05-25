using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Punch Position Tween")]
    [Description("Creates a punch position tween for configuration or use")]
    [Icon("DOTweenTween")]
    public class CreatePunchPositionTween : ActionTask
    {
        [RequiredField]
        public BBParameter<Vector3> PunchVector;

        [RequiredField]
        public BBParameter<float> Duration;

        public BBParameter<int> Vibration = new BBParameter<int> { value = 10 };
        public BBParameter<float> Elasticity = new BBParameter<float> { value = 1.0f };

        public BBParameter<bool> UseSnapping;

        [BlackboardOnly]
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Punch Tween To Position {0}", PunchVector);

                descriptionBuilder.AppendFormat("\nWith Vibration {0} and Elasticity {1}", Vibration, Elasticity);
                
                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0} {1} snapping", Duration, UseSnapping.value ? "with" : "without"); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.transform.DOPunchPosition(PunchVector.value, Duration.value, Vibration.value, Elasticity.value, UseSnapping.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}