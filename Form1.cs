namespace SemAlgoritmia
{
    public partial class Form1 : Form
    {
        Bitmap bmpImage;
        Bitmap bmpIDs;
        Bitmap bmpAnimation;

        Agent agent;
        Objetive objetive;

        List<Circle> circleList;
        Graph graph;

        public Form1()
        {
            InitializeComponent();

            circleList = new List<Circle>();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            bmpImage = new Bitmap(openFileDialog.FileName);
            bmpIDs = new Bitmap(openFileDialog.FileName);

            pictureBox.Image = bmpImage;


            buttonCreateGraph.Visible = true;

            treeView.Visible = false;
            groupBox.Visible = false;
            buttonRunSimulation.Visible = false;
            listBoxLog.Visible = false;
        }
    }
}