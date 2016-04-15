using System;
using Eto.Forms;
using Eto.Drawing;

namespace OmniEditorX
{
    /// <summary>
    /// A custom panel
    /// </summary>
    public class TextEditorX : RichTextArea
    {
        public TextEditorX()
        {
            PreLoad += SetUpEditor;
            Shown += LayoutEditor;
        }

        private void SetUpEditor(object sender, EventArgs e)
        {
            Font = new Font(FontFamilies.Monospace, 10);
        }

        private void LayoutEditor(object sender, EventArgs e)
        {
            this.Size = Parent.ClientSize;
        }
    }
}
