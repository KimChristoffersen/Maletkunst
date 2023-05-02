
using ClientApp.DAL.Client;
using Maletkunst.WinApp.ApiClient;
using Maletkunst.WinApp.DAL.Model;

namespace MaletKunst.WinApp;

public partial class MainForm : Form
{
    IPaintingsRestClient paintingsRestClient = new PaintingsRestClient();
    public MainForm() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e) => LoadData();

    private void LoadData()
    {
        GetAllPaintings();
        SetButtonsDeleteAndUpdateDisabled();
    }

    private void SetButtonsDeleteAndUpdateDisabled()
    {
        buttonDelete.Enabled = false;
        buttonUpdate.Enabled = false;
    }

    private void SetButtonsDeleteAndUpdateEnabled()
    {
        buttonDelete.Enabled = true;
        buttonUpdate.Enabled = true;
    }

    private void GetAllPaintings()
    {
        foreach (var painting in paintingsRestClient.GetAll())
        {
            listBoxPaintings.Items.Add(painting);
        }
    }

    private void listBoxPaintings_SelectedIndexChanged(object sender, EventArgs e) => GetSelectedPaitingFromList();

    private void GetSelectedPaitingFromList()
    {
        if (listBoxPaintings.SelectedIndex != -1)
        {
            SetButtonsDeleteAndUpdateEnabled();

            Painting painting = (Painting)listBoxPaintings.SelectedItem;

            textBoxId.Text = painting.Id.ToString();
            textBoxTitle.Text = painting.Title;
            textBoxPrice.Text = painting.Price.ToString();
            textBoxStock.Text = painting.Stock.ToString();
            textBoxArtist.Text = painting.Artist;
            comboBoxCategory.Text = painting.Category;
            textBoxDescription.Text = painting.Description;

            // LOADING IMAGE
            string imagePath = $"C:\\Users\\huygo\\Downloads\\{painting.Id}.jpg"; // PATH NEEDS TO BE CORRECTED
            if (File.Exists(imagePath)) { pictureBox1.Image = Image.FromFile(imagePath); }
            else { pictureBox1.Image = null; }
        }
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        textBoxId.Text = "";
        textBoxTitle.Text = "";
        textBoxPrice.Text = "";
        textBoxStock.Text = "";
        textBoxArtist.Text = "";
        comboBoxCategory.Text = "";
        textBoxDescription.Text = "";
        pictureBox1.Image = null;
        listBoxPaintings.SelectedItem = null;
        SetButtonsDeleteAndUpdateDisabled();
    }

    private void buttonCreate_Click(object sender, EventArgs e)
    {
        CreatePainting();
    }

    private void CreatePainting()
    {
        Painting painting = new()
        {
            Title = textBoxTitle.Text,
            Price = decimal.Parse(textBoxPrice.Text),
            Stock = int.Parse(textBoxStock.Text),
            Artist = textBoxArtist.Text,
            Category = comboBoxCategory.Text,
            Description = textBoxDescription.Text
            // Picture....
        };
        int createdId = paintingsRestClient.CreatePainting(painting);
        if (createdId == 0)
        {
            MessageBox.Show("Oprettelse af maleri mislykkedes", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show($"Maleri med id {createdId} er oprettet", "Succes", MessageBoxButtons.OK, MessageBoxIcon.None);
            listBoxPaintings.Items.Clear();
            LoadData();
            Clear();
        }
    }

    private void buttonDelete_Click(object sender, EventArgs e) => DeletePainting();

    private void DeletePainting()
    {
        int paintingToDeleteId = int.Parse(textBoxId.Text);
        if (paintingsRestClient.DeletePainting(paintingToDeleteId))
        {
            MessageBox.Show($"Maleri med id {paintingToDeleteId} er slettet", "Succes", MessageBoxButtons.OK, MessageBoxIcon.None);
            listBoxPaintings.Items.Clear();
            LoadData();
            Clear();
        }
        else
        {
            MessageBox.Show($"Maleri med id {paintingToDeleteId} er ikke slettet", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}