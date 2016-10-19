using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.States
{
    public class StaticState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new StaticState();
            }
            return instance;
        }

        public override void Draw(StatefulDrawingObject obj)
        {
            obj.RenderOnStaticView();
        }

        public override void Select(StatefulDrawingObject obj)
        {
            obj.ChangeState(EditState.GetInstance());
        }
    }
}
