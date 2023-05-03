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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBoxPaintings);
            // 
            // splitContainer1.Panel2
            // 
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
            splitContainer1.Size = new Size(733, 415);
            splitContainer1.SplitterDistance = 243;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 0;
            // 
            // listBoxPaintings
            // 
            listBoxPaintings.Dock = DockStyle.Fill;
            listBoxPaintings.FormattingEnabled = true;
            listBoxPaintings.ItemHeight = 15;
            listBoxPaintings.Location = new Point(0, 0);
            listBoxPaintings.Margin = new Padding(2);
            listBoxPaintings.Name = "listBoxPaintings";
            listBoxPaintings.Size = new Size(243, 415);
            listBoxPaintings.TabIndex = 0;
            listBoxPaintings.SelectedIndexChanged += listBoxPaintings_SelectedIndexChanged;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Items.AddRange(new object[] { "Aquaral", "Oliemaleri" });
            comboBoxCategory.Location = new Point(113, 211);
            comboBoxCategory.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(140, 23);
            comboBoxCategory.TabIndex = 31;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(359, 376);
            buttonClose.Margin = new Padding(3, 2, 3, 2);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(109, 30);
            buttonClose.TabIndex = 30;
            buttonClose.Text = "Ryd";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(245, 376);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(109, 30);
            buttonDelete.TabIndex = 29;
            buttonDelete.Text = "Slet";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(131, 376);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(109, 30);
            buttonUpdate.TabIndex = 28;
            buttonUpdate.Text = "Ændre";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(18, 376);
            buttonCreate.Margin = new Padding(3, 2, 3, 2);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(109, 30);
            buttonCreate.TabIndex = 27;
            buttonCreate.Text = "Opret";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(276, 76);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 156);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(17, 158);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(62, 15);
            labelStock.TabIndex = 21;
            labelStock.Text = "Lagerantal";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(17, 131);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(26, 15);
            labelPrice.TabIndex = 19;
            labelPrice.Text = "Pris";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(17, 105);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(29, 15);
            labelTitle.TabIndex = 17;
            labelTitle.Text = "Titel";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(113, 158);
            textBoxStock.Margin = new Padding(3, 2, 3, 2);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(140, 23);
            textBoxStock.TabIndex = 16;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(113, 130);
            textBoxPrice.Margin = new Padding(3, 2, 3, 2);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(140, 23);
            textBoxPrice.TabIndex = 15;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(113, 104);
            textBoxTitle.Margin = new Padding(3, 2, 3, 2);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(140, 23);
            textBoxTitle.TabIndex = 14;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(18, 79);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 13;
            labelId.Text = "Id";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(113, 76);
            textBoxId.Margin = new Padding(3, 2, 3, 2);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(140, 23);
            textBoxId.TabIndex = 12;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(17, 250);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(64, 15);
            labelDescription.TabIndex = 25;
            labelDescription.Text = "Beskrivelse";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(17, 210);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(51, 15);
            labelCategory.TabIndex = 24;
            labelCategory.Text = "Kategori";
            // 
            // labelArtist
            // 
            labelArtist.AutoSize = true;
            labelArtist.Location = new Point(18, 184);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(54, 15);
            labelArtist.TabIndex = 23;
            labelArtist.Text = "Kunstner";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(113, 250);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(357, 103);
            textBoxDescription.TabIndex = 22;
            // 
            // textBoxArtist
            // 
            textBoxArtist.Location = new Point(113, 184);
            textBoxArtist.Margin = new Padding(3, 2, 3, 2);
            textBoxArtist.Name = "textBoxArtist";
            textBoxArtist.Size = new Size(140, 23);
            textBoxArtist.TabIndex = 18;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.Location = new Point(17, 16);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(97, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Produkt";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 415);
            Controls.Add(splitContainer1);
            Margin = new Padding(2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maletkunst Produktmenu";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}