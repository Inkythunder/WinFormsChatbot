using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClaudeChat
{
    public partial class ApiKeyDialogue : Form
    {
        public ApiKeyDialogue()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The key the user typed without any surrounding spaces.
        /// </summary>
        public string ApiKey => keyBox.Text.Trim();

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ApiKey.Length == 0)
            {
                MessageBox.Show(this,
                    "Please paste your API key, or press Cancel to quit.",
                    "API Key needed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                DialogResult = DialogResult.None;
            }
        }
    }
}
