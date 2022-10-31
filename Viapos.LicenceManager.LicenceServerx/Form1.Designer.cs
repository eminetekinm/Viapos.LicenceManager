namespace Viapos.LicenceManager.LicenceServerx
{
    partial class Form1
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.baslat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.Label();
            this.txtSirkeetAdi = new System.Windows.Forms.Label();
            this.txtLisansSayisi = new System.Windows.Forms.Label();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerDurum = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 5);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(436, 360);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // baslat
            // 
            this.baslat.Appearance.BackColor = System.Drawing.Color.Red;
            this.baslat.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.baslat.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslat.Appearance.ForeColor = System.Drawing.Color.Black;
            this.baslat.Appearance.Options.UseBackColor = true;
            this.baslat.Appearance.Options.UseBorderColor = true;
            this.baslat.Appearance.Options.UseFont = true;
            this.baslat.Appearance.Options.UseForeColor = true;
            this.baslat.Location = new System.Drawing.Point(454, 5);
            this.baslat.Name = "baslat";
            this.baslat.Size = new System.Drawing.Size(273, 53);
            this.baslat.TabIndex = 1;
            this.baslat.Text = "SERVER BAŞLAT";
            this.baslat.Click += new System.EventHandler(this.baslat_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Kullanıcı Adı";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(9, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lisans Sayısı";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Şirket Adı";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.White;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(129, 412);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(319, 22);
            this.txtKullaniciAdi.TabIndex = 11;
            this.txtKullaniciAdi.Text = "Kullanıcı Adı";
            this.txtKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSirkeetAdi
            // 
            this.txtSirkeetAdi.BackColor = System.Drawing.Color.White;
            this.txtSirkeetAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSirkeetAdi.Location = new System.Drawing.Point(129, 451);
            this.txtSirkeetAdi.Name = "txtSirkeetAdi";
            this.txtSirkeetAdi.Size = new System.Drawing.Size(319, 22);
            this.txtSirkeetAdi.TabIndex = 11;
            this.txtSirkeetAdi.Text = "Şirket Adı";
            this.txtSirkeetAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLisansSayisi
            // 
            this.txtLisansSayisi.BackColor = System.Drawing.Color.White;
            this.txtLisansSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLisansSayisi.Location = new System.Drawing.Point(129, 482);
            this.txtLisansSayisi.Name = "txtLisansSayisi";
            this.txtLisansSayisi.Size = new System.Drawing.Size(319, 22);
            this.txtLisansSayisi.TabIndex = 11;
            this.txtLisansSayisi.Text = "Lisans Sayısı";
            this.txtLisansSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(454, 64);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(273, 405);
            this.memoEdit1.TabIndex = 14;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(454, 479);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(173, 22);
            this.textEdit1.TabIndex = 15;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(633, 475);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "GÖNDER";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Server Durumu:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServerDurum
            // 
            this.txtServerDurum.Appearance.BackColor = System.Drawing.Color.White;
            this.txtServerDurum.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerDurum.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtServerDurum.Appearance.Options.UseBackColor = true;
            this.txtServerDurum.Appearance.Options.UseFont = true;
            this.txtServerDurum.Appearance.Options.UseForeColor = true;
            this.txtServerDurum.AppearanceDisabled.ForeColor = System.Drawing.Color.Red;
            this.txtServerDurum.AppearanceDisabled.Options.UseForeColor = true;
            this.txtServerDurum.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.txtServerDurum.Location = new System.Drawing.Point(126, 380);
            this.txtServerDurum.Name = "txtServerDurum";
            this.txtServerDurum.Size = new System.Drawing.Size(322, 22);
            this.txtServerDurum.TabIndex = 19;
            this.txtServerDurum.Text = "Server Başlatılmadı";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 529);
            this.Controls.Add(this.txtServerDurum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.txtLisansSayisi);
            this.Controls.Add(this.txtSirkeetAdi);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baslat);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton baslat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtKullaniciAdi;
        private System.Windows.Forms.Label txtSirkeetAdi;
        private System.Windows.Forms.Label txtLisansSayisi;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LabelControl txtServerDurum;
    }
}

