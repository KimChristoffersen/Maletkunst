namespace MaletKunst.WinApp
{
    partial class MainForm
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
            splitContainer1 = new SplitContainer();
            listBoxPaintings = new ListBox();
            groupBoxStock = new GroupBox();
            radioButtonUnavailable = new RadioButton();
            radioButtonAvailable = new RadioButton();
            comboBoxCategory = new ComboBox();
            buttonClose = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonCreate = new Button();
            pictureBox1 = new PictureBox();
            labelStock = new Label();
            labelPrice = new Label();
            labelTitle = new Label();
            textBoxStock = new TextBox();
            textBoxPrice = new TextBox();
            textBoxTitle = new TextBox();
            labelId = new Label();
            textBoxId = new TextBox();
            labelDescription = new Label();
            labelCategory = new Label();
            labelArtist = new Label();
            textBoxDescription = new TextBox();
            textBoxArtist = new TextBox();
            labelHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2, 3, 2, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBoxPaintings);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxStock);
            splitContainer1.Panel2.Controls.Add(comboBoxCategory);
            splitContainer1.Panel2.Controls.Add(buttonClose);
            splitContainer1.Panel2.Controls.Add(buttonDelete);
            splitContainer1.Panel2.Controls.Add(buttonUpdate);
            splitContainer1.Panel2.Controls.Add(buttonCreate);
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Panel2.Controls.Add(labelStock);
            splitContainer1.Panel2.Controls.Add(labelPrice);
            splitContainer1.Panel2.Controls.Add(labelTitle);
            splitContainer1.Panel2.Controls.Add(textBoxStock);
            splitContainer1.Panel2.Controls.Add(textBoxPrice);
            splitContainer1.Panel2.Controls.Add(textBoxTitle);
            splitContainer1.Panel2.Controls.Add(labelId);
            splitContainer1.Panel2.Controls.Add(textBoxId);
            splitContainer1.Panel2.Controls.Add(labelDescription);
            splitContainer1.Panel2.Controls.Add(labelCategory);
            splitContainer1.Panel2.Controls.Add(labelArtist);
            splitContainer1.Panel2.Controls.Add(textBoxDescription);
            splitContainer1.Panel2.Controls.Add(textBoxArtist);
            splitContainer1.Panel2.Controls.Add(labelHeader);
            splitContainer1.Size = new Size(838, 553);
            splitContainer1.SplitterDistance = 277;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 0;
            // 
            // listBoxPaintings
            // 
            listBoxPaintings.Dock = DockStyle.Fill;
            listBoxPaintings.FormattingEnabled = true;
            listBoxPaintings.ItemHeight = 20;
            listBoxPaintings.Location = new Point(0, 0);
            listBoxPaintings.Margin = new Padding(2, 3, 2, 3);
            listBoxPaintings.Name = "listBoxPaintings";
            listBoxPaintings.Size = new Size(277, 553);
            listBoxPaintings.TabIndex = 0;
            listBoxPaintings.SelectedIndexChanged += listBoxPaintings_SelectedIndexChanged;
            // 
            // groupBoxStock
            // 
            groupBoxStock.Controls.Add(radioButtonUnavailable);
            groupBoxStock.Controls.Add(radioButtonAvailable);
            groupBoxStock.Location = new Point(129, 284);
            groupBoxStock.Name = "groupBoxStock";
            groupBoxStock.Size = new Size(159, 43);
            groupBoxStock.TabIndex = 32;
            groupBoxStock.TabStop = false;
            // 
            // radioButtonUnavailable
            // 
            radioButtonUnavailable.AutoSize = true;
            radioButtonUnavailable.Location = new Point(78, 1);
            radioButtonUnavailable.Name = "radioButtonUnavailable";
            radioButtonUnavailable.Size = new Size(53, 24);
            radioButtonUnavailable.TabIndex = 1;
            radioButtonUnavailable.TabStop = true;
            radioButtonUnavailable.Text = "Nej";
            radioButtonUnavailable.UseVisualStyleBackColor = true;
            // 
            // radioButtonAvailable
            // 
            radioButtonAvailable.AutoSize = true;
            radioButtonAvailable.Location = new Point(6, 1);
            radioButtonAvailable.Name = "radioButtonAvailable";
            radioButtonAvailable.Size = new Size(43, 24);
            radioButtonAvailable.TabIndex = 0;
            radioButtonAvailable.TabStop = true;
            radioButtonAvailable.Text = "Ja";
            radioButtonAvailable.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Items.AddRange(new object[] { "Aquaral", "Oliemaleri" });
            comboBoxCategory.Location = new Point(129, 209);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(159, 28);
            comboBoxCategory.TabIndex = 31;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(410, 501);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(125, 40);
            buttonClose.TabIndex = 30;
            buttonClose.Text = "Ryd";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(280, 501);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(125, 40);
            buttonDelete.TabIndex = 29;
            buttonDelete.Text = "Slet";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(150, 501);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(125, 40);
            buttonUpdate.TabIndex = 28;
            buttonUpdate.Text = "Ændre";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(21, 501);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(125, 40);
            buttonCreate.TabIndex = 27;
            buttonCreate.Text = "Opret";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(315, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 208);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(19, 284);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(84, 20);
            labelStock.TabIndex = 21;
            labelStock.Text = "Lagerstatus";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(19, 175);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(32, 20);
            labelPrice.TabIndex = 19;
            labelPrice.Text = "Pris";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(19, 140);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(38, 20);
            labelTitle.TabIndex = 17;
            labelTitle.Text = "Titel";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(256, 32);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(159, 27);
            textBoxStock.TabIndex = 16;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(129, 173);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(159, 27);
            textBoxPrice.TabIndex = 15;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(129, 137);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(159, 27);
            textBoxTitle.TabIndex = 14;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(21, 105);
            labelId.Name = "labelId";
            labelId.Size = new Size(22, 20);
            labelId.TabIndex = 13;
            labelId.Text = "Id";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(129, 101);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(159, 27);
            textBoxId.TabIndex = 12;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(19, 333);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(81, 20);
            labelDescription.TabIndex = 25;
            labelDescription.Text = "Beskrivelse";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(19, 212);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(66, 20);
            labelCategory.TabIndex = 24;
            labelCategory.Text = "Kategori";
            // 
            // labelArtist
            // 
            labelArtist.AutoSize = true;
            labelArtist.Location = new Point(19, 245);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(66, 20);
            labelArtist.TabIndex = 23;
            labelArtist.Text = "Kunstner";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(129, 333);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(407, 136);
            textBoxDescription.TabIndex = 22;
            // 
            // textBoxArtist
            // 
            textBoxArtist.Location = new Point(129, 245);
            textBoxArtist.Name = "textBoxArtist";
            textBoxArtist.Size = new Size(159, 27);
            textBoxArtist.TabIndex = 18;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.Location = new Point(19, 21);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(123, 38);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Produkt";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 553);
            Controls.Add(splitContainer1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maletkunst Produktmenu";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxStock.ResumeLayout(false);
            groupBoxStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox listBoxPaintings;
        private Label labelHeader;
        private Label labelStock;
        private Label labelPrice;
        private Label labelTitle;
        private TextBox textBoxStock;
        private TextBox textBoxPrice;
        private TextBox textBoxTitle;
        private Label labelId;
        private TextBox textBoxId;
        private Label labelDescription;
        private Label labelCategory;
        private Label labelArtist;
        private TextBox textBoxDescription;
        private TextBox textBoxArtist;
        private PictureBox pictureBox1;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private Button buttonClose;
        private ComboBox comboBoxCategory;
        private GroupBox groupBoxStock;
        private RadioButton radioButtonUnavailable;
        private RadioButton radioButtonAvailable;
    }
}