using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Restart Tween")]
    [Description("Restarts a given tween")]
    [Icon("DOTweenTween")]
    public class RestartTween : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        public BBParameter<bool> IncludeDelay;

        public BBParameter<bool> WaitUntilFinished;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Restart Tween {0}", Tween);

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

            Tween.value.Restart(IncludeDelay.value);

            if (!WaitUntilFinished.value)
            {
                EndAction(true);
            }
        }
    }
}