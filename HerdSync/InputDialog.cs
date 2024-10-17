using System;
using System.Windows.Forms;

namespace FarmMap
{
    public class InputDialog : Form
    {
        private TextBox txtInput;
        private ComboBox comboBoxInput; // Add a ComboBox
        private Button btnOk;
        private Button btnCancel;
        private Label lblPrompt;

        public string InputText => comboBoxInput.Visible ? comboBoxInput.SelectedItem?.ToString() : txtInput.Text;

        public InputDialog(string title, string prompt)
        {
            InitializeComponent();
            this.Text = title;
            lblPrompt.Text = prompt;
        }

        private void InitializeComponent()
        {
            this.txtInput = new TextBox();
            this.comboBoxInput = new ComboBox(); // Initialize ComboBox
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.lblPrompt = new Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 39);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(260, 22);
            this.txtInput.TabIndex = 0;
            // 
            // comboBoxInput
            // 
            this.comboBoxInput.Location = new System.Drawing.Point(12, 39); // Set same location as txtInput
            this.comboBoxInput.Name = "comboBoxInput";
            this.comboBoxInput.Size = new System.Drawing.Size(260, 22);
            this.comboBoxInput.TabIndex = 0;
            this.comboBoxInput.Visible = false; // Initially hidden
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 67);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(12, 19);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(0, 17);
            this.lblPrompt.TabIndex = 3;
            // 
            // InputDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboBoxInput); // Add ComboBox to the form
            this.Controls.Add(this.txtInput);
            this.Name = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void SetComboBoxItems(string[] items)
        {
            comboBoxInput.Items.Clear();
            comboBoxInput.Items.AddRange(items);
            comboBoxInput.Visible = true; // Show ComboBox
            txtInput.Visible = false; // Hide TextBox
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
