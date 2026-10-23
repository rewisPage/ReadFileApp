namespace ReadFileApp
{
    public partial class FrmOpenTextFile : Form
    {
        public FrmOpenTextFile()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DisplayToList();
        }

        private void DisplayToList()
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                if (Path.GetExtension(path).ToLower() == ".txt")
                {
                    lvShowText.Items.Clear();

                    using (StreamReader reader = File.OpenText(path))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            lvShowText.Items.Add(line);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Only .txt files are allowed.");
                }
            }
        }
    }
}