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
        public MainForm()
        {
            XamlReader.Load(this);
            Content = new StackLayout()
            {
                Items =
                {
                    new OmniEditorX.TextEditorX()
                },
            };
            Icon = Icon.FromResource("EPad.icon.ico");
        }

        protected void HandleQuit(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }
    }
}
