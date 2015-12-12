using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.Cameras
{
    [Category("DOTween/Tweens/Camera")]
    [Name("Create Pixel Rect Tween")]
    [Description("Creates a pixel rect tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Camera))]
    public class CreatePixelRectTween : ActionTask
    {

        public BBParameter<float> Duration;
        public BBParameter<Rect> To;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Pixel Rect Tween To {0}", To.value);
                
                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nIn {0}", Duration); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Camera) agent).DOPixelRect(To.value, Duration.value);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}