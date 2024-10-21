namespace PrintToBambu
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
            components = new System.ComponentModel.Container();
            printButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            accessCode = new TextBox();
            settingsBindingSource2 = new BindingSource(components);
            host = new TextBox();
            settingsBindingSource1 = new BindingSource(components);
            label1 = new Label();
            hostLabel = new Label();
            panel1 = new Panel();
            browseButton = new Button();
            path = new TextBox();
            logTextBox = new RichTextBox();
            openFileDialog = new OpenFileDialog();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingsBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingsBindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // printButton
            // 
            printButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            printButton.Location = new Point(498, 101);
            printButton.Margin = new Padding(2);
            printButton.Name = "printButton";
            printButton.Size = new Size(78, 20);
            printButton.TabIndex = 0;
            printButton.Text = "Print!";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(printButton, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(accessCode, 1, 2);
            tableLayoutPanel1.Controls.Add(host, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(hostLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 3);
            tableLayoutPanel1.Controls.Add(logTextBox, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(14, 12, 14, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(582, 339);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 75);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 5;
            label2.Text = "Path:";
            // 
            // accessCode
            // 
            accessCode.DataBindings.Add(new Binding("Text", settingsBindingSource2, "AccessCode", true));
            accessCode.Location = new Point(87, 53);
            accessCode.Margin = new Padding(2);
            accessCode.Name = "accessCode";
            accessCode.Size = new Size(141, 23);
            accessCode.TabIndex = 3;
            // 
            // settingsBindingSource2
            // 
            settingsBindingSource2.DataSource = typeof(Properties.Settings);
            // 
            // host
            // 
            host.DataBindings.Add(new Binding("Text", settingsBindingSource1, "Host", true));
            host.Location = new Point(87, 29);
            host.Margin = new Padding(2);
            host.Name = "host";
            host.Size = new Size(141, 23);
            host.TabIndex = 4;
            // 
            // settingsBindingSource1
            // 
            settingsBindingSource1.DataSource = typeof(Properties.Settings);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 51);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 2;
            label1.Text = "Access Code:";
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(6, 27);
            hostLabel.Margin = new Padding(2, 0, 2, 0);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(35, 15);
            hostLabel.TabIndex = 1;
            hostLabel.Text = "Host:";
            hostLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(browseButton);
            panel1.Controls.Add(path);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(87, 77);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(489, 20);
            panel1.TabIndex = 7;
            // 
            // browseButton
            // 
            browseButton.Dock = DockStyle.Right;
            browseButton.Location = new Point(411, 0);
            browseButton.Margin = new Padding(2);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(78, 20);
            browseButton.TabIndex = 7;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // path
            // 
            path.Dock = DockStyle.Left;
            path.Location = new Point(0, 0);
            path.Margin = new Padding(2);
            path.Name = "path";
            path.Size = new Size(384, 23);
            path.TabIndex = 6;
            // 
            // logTextBox
            // 
            tableLayoutPanel1.SetColumnSpan(logTextBox, 2);
            logTextBox.Dock = DockStyle.Fill;
            logTextBox.Location = new Point(7, 126);
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            logTextBox.Size = new Size(568, 207);
            logTextBox.TabIndex = 8;
            logTextBox.Text = "";
            // 
            // openFileDialog
            // 
            openFileDialog.AddToRecent = false;
            openFileDialog.DefaultExt = "gocde";
            openFileDialog.FileName = "openFileDialog1";
            openFileDialog.Filter = "GCode files|*.gcode";
            // 
            // Form1
            // 
            AcceptButton = printButton;
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(582, 339);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "GCode To Bambu";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingsBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingsBindingSource1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button printButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label hostLabel;
        private Label label1;
        private TextBox accessCode;
        private TextBox host;
        private Label label2;
        private OpenFileDialog openFileDialog;
        private TextBox path;
        private Panel panel1;
        private Button browseButton;
        private RichTextBox logTextBox;
        private BindingSource settingsBindingSource2;
        private BindingSource settingsBindingSource1;
    }
}
