using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Path Tween")]
    [Description("Creates a path tween for configuration or use")]
    [Icon("DOTweenPath")]
    public class CreatePathTween : ActionTask
    {
        [RequiredField]
        public BBVectorList VectorPath;
        
        [RequiredField]
        public BBFloat Duration;

        public PathType PathType = PathType.Linear; 
        public PathMode PathMode = PathMode.Full3D; 

        public BBInt Resolution = new BBInt{ value = 10 };

        [BlackboardOnly] 
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Path Tween along {0}", VectorPath);
                descriptionBuilder.AppendFormat("\nIn {0} with resolution of {1}", Duration, Resolution);
                descriptionBuilder.AppendFormat("\nWith type {0} and mode {1}", PathType, PathMode); 
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = agent.transform.DOPath(VectorPath.value.ToArray(), Duration.value, PathType, PathMode, Resolution.value);
            tweener.Pause();
            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}