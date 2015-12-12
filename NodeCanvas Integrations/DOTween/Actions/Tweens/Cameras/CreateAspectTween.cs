using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.Cameras
{
    [Category("DOTween/Tweens/Camera")]
    [Name("Create Aspect Tween")]
    [Description("Creates an aspect tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Camera))]
    public class CreateAspectTween : ActionTask
    {

        public BBParameter<float> Duration;
        public BBParameter<float> To;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Aspect Tween To {0}", To.value);
                
                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0}", Duration); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Camera) agent).DOAspect(To.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}