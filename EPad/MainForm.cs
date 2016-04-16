using System;
using System.IO;
using System.Reflection;
using Eto.Drawing;
using Eto.Forms;

namespace EPad
{
    public class MainForm : Form
    {
        private Splitter _splitter1;
        private OmniEditorX.TextEditorX _textEditor;
        private WebView _webView;

        public MainForm()
        {
            this.ClientSize = new Size(800, 480);
            _textEditor = new OmniEditorX.TextEditorX()
            {
                Width = this.ClientSize.Width / 3,
                Height = this.ClientSize.Height,
            };
            _webView = new WebView();
            _webView.Width = (2 / 3) * ClientSize.Width;
            _splitter1 = new Splitter()
            {
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height,
                Orientation = Orientation.Horizontal,
                Panel1 = _textEditor,
                Panel2 = _webView,
            };
            Content = new StackLayout()
            {
                Items =
                {
                    _splitter1
                },
            };
            Icon = Icon.FromResource("EPad.icon.ico");
            _textEditor.TextChanged += TextEditor_TextChanged;
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            Application.Instance.AsyncInvoke(() => { _webView.LoadHtml(CreateProcessingJsSource(_textEditor.Text)); });
        }

        private string CreateProcessingJsSource(string source)
        {
            string template = ReadTextResource("EPad.Templates.pjs.html");
            string processedSource = template.Replace("/**PJS**/", source);
            return processedSource;
        }

        private string ReadTextResource(string resourceName)
        {
            var assembly = typeof(MainForm).GetTypeInfo().Assembly;
            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _splitter1.Width = this.ClientSize.Width;
            _splitter1.Height = this.ClientSize.Height;
            _splitter1.Orientation = Orientation.Horizontal;
        }

        protected void HandleQuit(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }
    }
}