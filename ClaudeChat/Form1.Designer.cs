namespace ClaudeChat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            busyBar = new ProgressBar();
            inputPanel = new Panel();
            inputBox = new TextBox();
            sendButton = new Button();
            historyBox = new RichTextBox();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // busyBar
            // 
            busyBar.Dock = DockStyle.Bottom;
            busyBar.Location = new Point(0, 555);
            busyBar.Name = "busyBar";
            busyBar.Size = new Size(744, 6);
            busyBar.Style = ProgressBarStyle.Marquee;
            busyBar.TabIndex = 1;
            busyBar.Visible = false;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(inputBox);
            inputPanel.Controls.Add(sendButton);
            inputPanel.Dock = DockStyle.Bottom;
            inputPanel.Location = new Point(0, 509);
            inputPanel.Name = "inputPanel";
            inputPanel.Padding = new Padding(8);
            inputPanel.Size = new Size(744, 46);
            inputPanel.TabIndex = 2;
            // 
            // inputBox
            // 
            inputBox.Dock = DockStyle.Fill;
            inputBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputBox.Location = new Point(8, 8);
            inputBox.Multiline = true;
            inputBox.Name = "inputBox";
            inputBox.PlaceholderText = "Type a message and press Enter...";
            inputBox.Size = new Size(638, 30);
            inputBox.TabIndex = 0;
            inputBox.KeyDown += inputBox_KeyDown;
            // 
            // sendButton
            // 
            sendButton.Dock = DockStyle.Right;
            sendButton.Location = new Point(646, 8);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(90, 30);
            sendButton.TabIndex = 6;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // historyBox
            // 
            historyBox.AccessibleName = "history";
            historyBox.BackColor = SystemColors.Window;
            historyBox.BorderStyle = BorderStyle.None;
            historyBox.Dock = DockStyle.Fill;
            historyBox.Font = new Font("Segoe UI", 10F);
            historyBox.Location = new Point(0, 0);
            historyBox.Name = "historyBox";
            historyBox.ReadOnly = true;
            historyBox.Size = new Size(744, 509);
            historyBox.TabIndex = 3;
            historyBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 561);
            Controls.Add(historyBox);
            Controls.Add(inputPanel);
            Controls.Add(busyBar);
            MinimumSize = new Size(420, 320);
            Name = "Form1";
            Text = "Claude Chat";
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar busyBar;
        private Panel inputPanel;
        private Button sendButton;
        private TextBox inputBox;
        private RichTextBox historyBox;
    }
}
