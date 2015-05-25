using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Pause Tween")]
    [Description("Pauses a given tween")]
    [Icon("DOTweenTween")]
    public class PauseTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Pause Tween {0}", Tween);
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.Pause();
            EndAction(true);
        }
    }
}