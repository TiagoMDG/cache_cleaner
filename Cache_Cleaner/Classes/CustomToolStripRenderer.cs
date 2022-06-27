using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cache_Cleaner
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() { }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //you may want to change this based on the toolstrip's dock or layout style
            LinearGradientMode mode = LinearGradientMode.Horizontal;

            using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, System.Drawing.Color.AliceBlue, ColorTable.MenuStripGradientEnd, mode))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
    }
}
