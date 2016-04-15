using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.Reflection;
using System.IO;

namespace EPad
{
    public class MainForm : Form
    {
        Splitter splitter1;
        OmniEditorX.TextEditorX textEditor;
        WebView webView;

        public MainForm()
        {
            this.ClientSize = new Size(640, 480);
            textEditor = new OmniEditorX.TextEditorX()
            {
                Width = this.ClientSize.Width / 2,
                Height = this.ClientSize.Height,
            };
            webView = new WebView();
            splitter1 = new Splitter()
            {
                Width = this.ClientSize.Width,
                Orientation = Orientation.Horizontal,
                Panel1 = textEditor,
                Panel2 = webView,
            };
            Content = new StackLayout()
            {
                Items =
                {
                    splitter1
                },
            };
            Icon = Icon.FromResource("EPad.icon.ico");
            textEditor.TextChanged += TextEditor_TextChanged;
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            webView.LoadHtml(textEditor.Text);
        }

        protected void HandleQuit(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }
    }
}
