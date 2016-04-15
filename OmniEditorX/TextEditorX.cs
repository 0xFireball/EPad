using System;
using Eto.Forms;
using Eto.Drawing;
using System.Text.RegularExpressions;

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

        string lastText = "";

        int tabLevel = 0;
        string tokens = "(EPad)";

        private void SetUpEditor(object sender, EventArgs e)
        {
            Font = new Font(FontFamilies.Monospace, 10);
            SelectionForeground = Colors.Black;
        }

        private void LayoutEditor(object sender, EventArgs e)
        {
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Text != lastText)
            {
                lastText = Text;
                Regex rX = new Regex(tokens);
                MatchCollection matches = rX.Matches(Text);
                int StartCursorPosition = Selection.Start;
                foreach (Match m in matches)
                {
                    int startIndex = m.Index;
                    int StopIndex = m.Index + m.Length;
                    Select(startIndex, StopIndex);
                    SelectionForeground = Colors.Blue;
                    SelectionBold = true;
                    Select(StartCursorPosition, StartCursorPosition - 1);
                    SelectionBold = false;
                    SelectionForeground = Colors.Black;
                    Select(StartCursorPosition + 1, StartCursorPosition);
                }
            }
        }

        protected void Select(int startIndex, int stopIndex)
        {
            Selection = new Range<int>(startIndex, stopIndex);
        }
    }
}
