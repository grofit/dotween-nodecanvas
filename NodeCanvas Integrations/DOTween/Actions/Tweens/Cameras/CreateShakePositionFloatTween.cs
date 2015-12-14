using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.Cameras
{
    [Category("DOTween/Tweens/Camera")]
    [Name("Create Camera Shake Position Tween (Float Strength)")]
    [Description("Creates a camera shake position tween with float strength for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Camera))]
    public class CreateShakePositionFloatTween : ActionTask
    {

        public BBParameter<float> Duration;
        public BBParameter<float> Strength;
        public BBParameter<int> vibrato;
        public BBParameter<float> randomness;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();

                descriptionBuilder.AppendFormat("Camera Shake Position Tween With Strength of {0}", Strength.value);

                descriptionBuilder.AppendFormat("\nWith vibrato of {0}", vibrato.value);

                descriptionBuilder.AppendFormat("\nWith randomness of {0}", randomness.value);

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nFor {0}", Duration); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {

            var tweener = ((Camera) agent).DOShakePosition(Duration.value, Strength.value, vibrato.value, randomness.value);

            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}