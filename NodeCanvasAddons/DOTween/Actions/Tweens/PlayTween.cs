using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Play Tween")]
    [Description("Plays a given tween")]
    [Icon("DOTweenTween")]
    public class PlayTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly] 
        public BBTween Tween;

        public BBBool WaitUntilFinished;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Play Tween {0}", Tween);

                if (!WaitUntilFinished.isNone && !WaitUntilFinished.isNull && WaitUntilFinished.value)
                {
                    descriptionBuilder.AppendFormat("\nAnd wait until finished");
                }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            if (WaitUntilFinished.value)
            {
                Tween.value.OnComplete(() => EndAction(true));
            }

            Tween.value.Play();

            if (!WaitUntilFinished.value)
            {
                EndAction(true);
            }
        }
    }
}