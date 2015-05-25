using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Toggle Tween Pause")]
    [Description("Toggles pause on a tween")]
    [Icon("DOTweenTween")]
    public class PauseToggleTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Toggle Tween Pause {0}", Tween);
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tween.value.TogglePause();
            EndAction(true);
        }
    }
}