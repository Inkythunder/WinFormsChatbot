namespace ClaudeChat
{
    partial class ApiKeyDialogue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            promptLabel = new Label();
            keyBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Location = new Point(12, 12);
            promptLabel.Name = "promptLabel";
            promptLabel.Size = new Size(439, 15);
            promptLabel.TabIndex = 0;
            promptLabel.Text = "Paste your Anthropic API key. It is kept in memory only while the application runs.";
            // 
            // keyBox
            // 
            keyBox.Location = new Point(12, 40);
            keyBox.Name = "keyBox";
            keyBox.Size = new Size(420, 23);
            keyBox.TabIndex = 1;
            keyBox.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(276, 80);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(357, 80);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // ApiKeyDialogue
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(453, 121);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(keyBox);
            Controls.Add(promptLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApiKeyDialogue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApiKeyDialogue";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label promptLabel;
        private TextBox keyBox;
        private Button okButton;
        private Button cancelButton;
    }
}