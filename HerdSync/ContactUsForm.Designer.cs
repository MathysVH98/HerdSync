namespace HerdSync
{
    partial class ContactUsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPrompt;
        private Label lblContactDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPrompt = new Label();
            lblContactDetails = new Label();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(10, 8);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(363, 15);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "What would you like to know or is there anything we can help with?";
            // 
            // lblContactDetails
            // 
            lblContactDetails.AutoSize = true;
            lblContactDetails.Location = new Point(73, 90);
            lblContactDetails.Name = "lblContactDetails";
            lblContactDetails.Size = new Size(200, 45);
            lblContactDetails.TabIndex = 3;
            lblContactDetails.Text = "You can contact us directly at:\nEmail: tj.vanheerden717@gmail.com\nPhone: +27 78 318 6923";
            // 
            // ContactUsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 375);
            Controls.Add(lblContactDetails);
            Controls.Add(lblPrompt);
            Name = "ContactUsForm";
            Text = "Contact Us";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
