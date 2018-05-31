using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.GameObjects
{
    [Category("DOTween/Tweens/GameObjects")]
    [Name("Create Path Tween")]
    [Description("Creates a path tween for configuration or use")]
    [Icon("DOTweenPath")]
    public class CreatePathTween : ActionTask
    {
        [RequiredField]
        public BBParameter<List<Vector3>> VectorPath;
        
        [RequiredField]
        public BBParameter<float> Duration;

        public PathType PathType = PathType.Linear; 
        public PathMode PathMode = PathMode.Full3D; 

        public BBParameter<int> Resolution = new BBParameter<int>{ value = 10 };

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

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