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

        private void buttonCreateGraph_Click(object sender, EventArgs e)
        {
            circleList.Clear();

            findCircles();

            graph = new Graph(circleList);

            pictureBox.Image = null;
            pictureBox.BackgroundImage = bmpIDs;
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;

            fillTree();
            fillComboBoxes();

            drawGraph();

            treeView.Visible = true;
            groupBox.Visible = true;
            buttonRunSimulation.Visible = true;

            buttonRunSimulation.Enabled = false;
            listBoxLog.Visible = false;
        }



        bool isWhite(Color color)
        {
            if (color.R == 255)
                if (color.G == 255)
                    if (color.B == 255)
                        return true;
            return false;
        }

        bool isBlack(Color color)
        {
            if(color.R == 0)
                if(color.G == 0)
                    if(color.B == 0)
                        return true;
            return false;
        }

        int getLeftMostPixel(int x, int y)
        {
            int leftMostPixel = x;
            Color c = bmpImage.GetPixel(x, y);

            while (isBlack(c)) {
                leftMostPixel--;
                c = bmpImage.GetPixel(leftMostPixel, y);
            }

            return leftMostPixel;
        }

        int getRightMostPixel(int x, int y)
        {
            int rightMostPixel = x;
            Color c = bmpImage.GetPixel(x, y);

            while (isBlack(c)) {
                rightMostPixel++;
                c = bmpImage.GetPixel(rightMostPixel, y);
            }

            return rightMostPixel;
        }

        int getBottomMostPixel(int x, int y)
        {
            int bottomMostPixel = y;
            Color c = bmpImage.GetPixel(x, y);

            while (isBlack(c)) {
                bottomMostPixel++;
                c = bmpImage.GetPixel(x, bottomMostPixel);
            }

            return bottomMostPixel;
        }

        void findCircles()
        {
            Color c_i;

            for (int y_i = 0; y_i < bmpImage.Height; y_i++)
                for (int x_i = 0; x_i < bmpImage.Width; x_i++) {
                    c_i = bmpImage.GetPixel(x_i, y_i);

                    if (isBlack(c_i))
                        findCenter(x_i, y_i);
                }
        }

        void findCenter(int x, int y)
        {
            Point p = new Point();

            p.Y = ((getBottomMostPixel(x, y) - y) / 2) + y;
            int radius = (getRightMostPixel(x, p.Y) - getLeftMostPixel(x, p.Y)) / 2;
            p.X = getLeftMostPixel(x, p.Y) + radius;

            circleList.Add(new Circle(circleList.Count + 1, p, radius));

            drawCircle(p.X, p.Y, radius, bmpImage, Color.BlueViolet);
        }

        void drawCircle(int x, int y, int radius, Bitmap bmp, Color color)
        {
            Graphics g = Graphics.FromImage(bmp);
            Brush b = new SolidBrush(color);

            g.FillEllipse(b, x - radius - 5, y - radius - 5, (radius * 2) + 10, (radius * 2) + 10);
        }

        void drawID(int x, int y, int id)
        {
            Graphics g = Graphics.FromImage(bmpIDs);
            Font f = new Font("Cascadia Code", 18);
            SolidBrush b = new SolidBrush(Color.Red);

            g.DrawString(id.ToString(), f, b, x - 30, y - 30);
        }

        void drawLines()
        {
            Graphics g = Graphics.FromImage(bmpIDs);
            Pen p = new Pen(Color.BlueViolet, 1);

            Vertex v_i;

            for (int i = 0; i < graph.VertexCount; i++) {
                v_i = graph.getVertexAt(i);

                for (int j = 0; j < v_i.EdgesCount; j++)
                    g.DrawLine(p, v_i.Position, v_i.getDestinationAt(j).Position);
            }

        }

        void drawGraph()
        {
            drawLines();

            // dibujar circulos sobre las lineas
            for (int i = 0; i < circleList.Count; i++)
                drawCircle(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].R, bmpIDs, Color.Black);

            // dibujar IDs sobre los circulos
            for (int i = 0; i < circleList.Count; i++)
                drawID(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].ID);

            pictureBox.Refresh();
        }


        void fillTree()
        {
            treeView.Nodes.Clear();

            Vertex v_i;

            for (int i = 0; i < graph.VertexCount; i++) {
                v_i = graph.getVertexAt(i);
                TreeNode node = new TreeNode(v_i.ToString());

                for (int j = 0; j < v_i.EdgesCount; j++) {
                    TreeNode nodeSon = new TreeNode(v_i.getDestinationAt(j).ToString());
                    node.Nodes.Add(nodeSon);
                }
                treeView.Nodes.Add(node);
            }
        }

        void fillComboBoxes()
        {
            comboBoxAgentSelection.Items.Clear();
            comboBoxObjetiveSelection.Items.Clear();

            Vertex v_i;

            for (int i = 0; i < graph.VertexCount; i++)
            {
                v_i = graph.getVertexAt(i);

                comboBoxAgentSelection.Items.Add(v_i.ToString());
                comboBoxObjetiveSelection.Items.Add(v_i.ToString());
            }
        }




    }
}