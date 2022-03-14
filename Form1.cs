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

        }
    }
}