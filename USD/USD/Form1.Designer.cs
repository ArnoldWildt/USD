namespace USD
{
    partial class usd_form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usd_form));
            this.btn_eingabe = new System.Windows.Forms.Button();
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.txt_ontime = new System.Windows.Forms.TextBox();
            this.txt_offtime = new System.Windows.Forms.TextBox();
            this.txt_number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_zeit = new System.Windows.Forms.Label();
            this.list_box = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.lbl_arduino_connected = new System.Windows.Forms.Label();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.save_file = new System.Windows.Forms.SaveFileDialog();
            this.cbo_offtime = new System.Windows.Forms.ComboBox();
            this.cbo_ontime = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.background = new System.Windows.Forms.PictureBox();
            this.connect_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_eingabe
            // 
            this.btn_eingabe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btn_eingabe.FlatAppearance.BorderSize = 0;
            this.btn_eingabe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eingabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eingabe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_eingabe.Image = global::USD.Properties.Resources.enter;
            this.btn_eingabe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eingabe.Location = new System.Drawing.Point(-2, 219);
            this.btn_eingabe.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eingabe.Name = "btn_eingabe";
            this.btn_eingabe.Size = new System.Drawing.Size(190, 41);
            this.btn_eingabe.TabIndex = 0;
            this.btn_eingabe.Text = "Eingabe";
            this.btn_eingabe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eingabe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_eingabe.UseVisualStyleBackColor = false;
            this.btn_eingabe.Click += new System.EventHandler(this.btn_eingabe_Click);
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btn_start_stop.Enabled = false;
            this.btn_start_stop.FlatAppearance.BorderSize = 0;
            this.btn_start_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start_stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_start_stop.Image = ((System.Drawing.Image)(resources.GetObject("btn_start_stop.Image")));
            this.btn_start_stop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_start_stop.Location = new System.Drawing.Point(-2, 264);
            this.btn_start_stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(190, 41);
            this.btn_start_stop.TabIndex = 1;
            this.btn_start_stop.Text = "Start";
            this.btn_start_stop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_start_stop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_start_stop.UseVisualStyleBackColor = false;
            this.btn_start_stop.Click += new System.EventHandler(this.btn_start_stop_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btn_pause.Enabled = false;
            this.btn_pause.FlatAppearance.BorderSize = 0;
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_pause.Image = ((System.Drawing.Image)(resources.GetObject("btn_pause.Image")));
            this.btn_pause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pause.Location = new System.Drawing.Point(-2, 309);
            this.btn_pause.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(190, 41);
            this.btn_pause.TabIndex = 2;
            this.btn_pause.Text = "Pause";
            this.btn_pause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pause.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // txt_ontime
            // 
            this.txt_ontime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ontime.Location = new System.Drawing.Point(-2, 67);
            this.txt_ontime.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ontime.Name = "txt_ontime";
            this.txt_ontime.Size = new System.Drawing.Size(129, 22);
            this.txt_ontime.TabIndex = 4;
            // 
            // txt_offtime
            // 
            this.txt_offtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_offtime.Location = new System.Drawing.Point(-2, 122);
            this.txt_offtime.Margin = new System.Windows.Forms.Padding(2);
            this.txt_offtime.Name = "txt_offtime";
            this.txt_offtime.Size = new System.Drawing.Size(129, 22);
            this.txt_offtime.TabIndex = 5;
            // 
            // txt_number
            // 
            this.txt_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_number.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_number.Location = new System.Drawing.Point(-2, 176);
            this.txt_number.Margin = new System.Windows.Forms.Padding(2);
            this.txt_number.Name = "txt_number";
            this.txt_number.Size = new System.Drawing.Size(129, 22);
            this.txt_number.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Einschaltzeit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ausschaltzeit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Periodenanzahl";
            // 
            // progress_bar
            // 
            this.progress_bar.BackColor = System.Drawing.Color.Black;
            this.progress_bar.Location = new System.Drawing.Point(215, 40);
            this.progress_bar.Margin = new System.Windows.Forms.Padding(2);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(267, 24);
            this.progress_bar.Step = 1;
            this.progress_bar.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(201, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Zeitanzeige";
            // 
            // lbl_zeit
            // 
            this.lbl_zeit.AutoSize = true;
            this.lbl_zeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_zeit.Location = new System.Drawing.Point(503, 46);
            this.lbl_zeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_zeit.Name = "lbl_zeit";
            this.lbl_zeit.Size = new System.Drawing.Size(0, 16);
            this.lbl_zeit.TabIndex = 14;
            // 
            // list_box
            // 
            this.list_box.FormattingEnabled = true;
            this.list_box.Location = new System.Drawing.Point(205, 142);
            this.list_box.Margin = new System.Windows.Forms.Padding(2);
            this.list_box.Name = "list_box";
            this.list_box.Size = new System.Drawing.Size(641, 199);
            this.list_box.TabIndex = 15;
            this.list_box.SelectedIndexChanged += new System.EventHandler(this.list_box_SelectedIndexChanged);
            this.list_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_box_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(201, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Befehlsliste";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(684, 357);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(79, 37);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Speichern";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(767, 357);
            this.btn_load.Margin = new System.Windows.Forms.Padding(2);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(79, 37);
            this.btn_load.TabIndex = 18;
            this.btn_load.Text = "Laden";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lbl_arduino_connected
            // 
            this.lbl_arduino_connected.AutoSize = true;
            this.lbl_arduino_connected.BackColor = System.Drawing.Color.Transparent;
            this.lbl_arduino_connected.Location = new System.Drawing.Point(10, 381);
            this.lbl_arduino_connected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_arduino_connected.Name = "lbl_arduino_connected";
            this.lbl_arduino_connected.Size = new System.Drawing.Size(117, 13);
            this.lbl_arduino_connected.TabIndex = 19;
            this.lbl_arduino_connected.Text = "Arduino nicht gefunden";
            // 
            // open_file
            // 
            this.open_file.FileName = "openFileDialog1";
            // 
            // cbo_offtime
            // 
            this.cbo_offtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_offtime.FormattingEnabled = true;
            this.cbo_offtime.Items.AddRange(new object[] {
            "ms",
            "s",
            "min",
            "h"});
            this.cbo_offtime.Location = new System.Drawing.Point(128, 122);
            this.cbo_offtime.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_offtime.Name = "cbo_offtime";
            this.cbo_offtime.Size = new System.Drawing.Size(60, 21);
            this.cbo_offtime.TabIndex = 22;
            // 
            // cbo_ontime
            // 
            this.cbo_ontime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_ontime.FormattingEnabled = true;
            this.cbo_ontime.ItemHeight = 13;
            this.cbo_ontime.Items.AddRange(new object[] {
            "ms",
            "s",
            "min",
            "h"});
            this.cbo_ontime.Location = new System.Drawing.Point(128, 67);
            this.cbo_ontime.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_ontime.Name = "cbo_ontime";
            this.cbo_ontime.Size = new System.Drawing.Size(60, 21);
            this.cbo_ontime.TabIndex = 23;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Gray;
            this.background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("background.BackgroundImage")));
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background.InitialImage = null;
            this.background.Location = new System.Drawing.Point(-2, -3);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(190, 412);
            this.background.TabIndex = 24;
            this.background.TabStop = false;
            // 
            // connect_timer
            // 
            this.connect_timer.Interval = 2000;
            this.connect_timer.Tick += new System.EventHandler(this.connect_timer_Tick);
            // 
            // usd_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(857, 405);
            this.Controls.Add(this.cbo_ontime);
            this.Controls.Add(this.cbo_offtime);
            this.Controls.Add(this.lbl_arduino_connected);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.list_box);
            this.Controls.Add(this.lbl_zeit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_number);
            this.Controls.Add(this.txt_offtime);
            this.Controls.Add(this.txt_ontime);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_start_stop);
            this.Controls.Add(this.btn_eingabe);
            this.Controls.Add(this.background);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usd_form";
            this.Text = "Universal switching device";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_eingabe;
        private System.Windows.Forms.Button btn_start_stop;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.TextBox txt_ontime;
        private System.Windows.Forms.TextBox txt_offtime;
        private System.Windows.Forms.TextBox txt_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_zeit;
        private System.Windows.Forms.ListBox list_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label lbl_arduino_connected;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.SaveFileDialog save_file;
        private System.Windows.Forms.ComboBox cbo_offtime;
        private System.Windows.Forms.ComboBox cbo_ontime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Timer connect_timer;
    }
}

