namespace SemAlgoritmia
{
    public partial class Form1 : Form
    {
        Bitmap bmpImage;
        Bitmap bmpGraph;
        Bitmap bmpAnimation;

        List<Agent> agents;
        Objetive objetive;

        bool isObjetiveCreated;

        List<Circle> circleList;
        Graph graph;

        List<DijkstraElement> VD;

        public Form1()
        {
            InitializeComponent();

            circleList = new List<Circle>();

            agents = new List<Agent>();

            objetive = new Objetive();
            isObjetiveCreated = false;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            bmpImage = new Bitmap(openFileDialog.FileName);
            bmpGraph = new Bitmap(openFileDialog.FileName);

            pictureBox.Image = bmpImage;


            buttonCreateGraph.Visible = true;
            treeView.Visible = false;
            groupBox.Visible = false;
            groupBoxShortestPath.Visible = false;
            buttonRunSimulation.Visible = false;
            buttonShortestPath.Enabled = true;
        }

        private void buttonCreateGraph_Click(object sender, EventArgs e)
        {
            circleList.Clear();

            findCircles();

            for (int i=0; i<circleList.Count; i++)
                drawCircle(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].R, bmpImage, Color.Black, 3);


            graph = new Graph(circleList, bmpImage);

            pictureBox.Image = null;
            pictureBox.BackgroundImage = bmpGraph;
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;

            fillTree();
            fillComboBoxes();

            drawGraph();

            treeView.Visible = true;
            groupBox.Visible = true;
            groupBoxShortestPath.Visible = true;
            buttonRunSimulation.Visible = true;

            buttonRunSimulation.Enabled = false;
        }

        private void buttonAddAgents_Click(object sender, EventArgs e)
        {
            if(comboBoxAgentSelection.Items.Count == 1) {
                MessageBox.Show("Ya no es posible agregar más agentes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonAddAgents.Enabled = false;
                return;
            }


            int selectedIndex = comboBoxAgentSelection.SelectedIndex;

            if(selectedIndex  == -1) {
                MessageBox.Show("Debes seleccionar un índice válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Agent agent = new Agent((Vertex)comboBoxAgentSelection.SelectedItem);
            agents.Add(agent);

            drawCircle(agent.AgentVertex.Position.X, agent.AgentVertex.Position.Y, 8, bmpGraph, Color.CornflowerBlue, 2);
            pictureBox.Refresh();

            comboBoxAgentSelection.Items.RemoveAt(selectedIndex);
            comboBoxObjetiveSelection.Items.RemoveAt(selectedIndex);

            if(agents.Count > 0 && isObjetiveCreated)
                buttonRunSimulation.Enabled = true;
        }

        private void buttonAddObjetive_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxObjetiveSelection.SelectedIndex;

            if(selectedIndex == -1) {
                MessageBox.Show("Debes seleccionar un índice válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            objetive.ObjetiveVertex = (Vertex)comboBoxObjetiveSelection.SelectedItem;

            drawCircle(objetive.ObjetiveVertex.Position.X, objetive.ObjetiveVertex.Position.Y, 4, bmpGraph, Color.LightYellow, 2);
            pictureBox.Refresh();

            comboBoxAgentSelection.Items.RemoveAt(selectedIndex);
            comboBoxObjetiveSelection.Items.RemoveAt(selectedIndex);
            comboBoxShortestPath.Items.Remove(objetive.ObjetiveVertex);

            isObjetiveCreated = true;

            groupBoxShortestPath.Visible = true;
            buttonShortestPath.Enabled = true;
            buttonAddObjetive.Enabled = false;

            if(agents.Count > 0 && isObjetiveCreated)
                buttonRunSimulation.Enabled = true;
        }

        private void buttonShortestPath_Click(object sender, EventArgs e)
        {
            if(comboBoxShortestPath.SelectedIndex == -1) {
                MessageBox.Show("Debes seleccionar un índice válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Vertex v_o = (Vertex)comboBoxShortestPath.SelectedItem;
            Vertex v_d = objetive.ObjetiveVertex;
            
            VD = graph.dijkstra(graph.getIndex(v_d));

            List<Edge> shortestPath = new List<Edge>();

            while(v_o != v_d) {

                for(int i=0; i<VD.Count; i++) 
                    if(VD[i].Vertex == v_o) {
                        shortestPath.Add(v_o.getEdge(VD[i].ComimgFrom));
                        v_o = VD[i].ComimgFrom;
                        break;
                    }
            }


        }

        private void buttonRunSimulation_Click(object sender, EventArgs e)
        {
            bmpAnimation = new Bitmap(bmpGraph);
            pictureBox.Image = bmpAnimation;

            simulation();
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

            for (int y_i=0; y_i<bmpImage.Height; y_i++)
                for (int x_i=0; x_i<bmpImage.Width; x_i++) {
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

            drawCircle(p.X, p.Y, radius, bmpImage, Color.BlueViolet, 3);
        }

        void drawCircle(int x, int y, int radius, Bitmap bmp, Color color, int extraSize)
        {
            Graphics g = Graphics.FromImage(bmp);
            Brush b = new SolidBrush(color);

            g.FillEllipse(b, x - radius - extraSize/2, y - radius - extraSize/2, (radius * 2) + extraSize, (radius * 2) + extraSize);
        }

        void drawID(int x, int y, int id)
        {
            Graphics g = Graphics.FromImage(bmpGraph);
            Font f = new Font("Cascadia Code", 18);
            SolidBrush b = new SolidBrush(Color.Red);

            g.DrawString(id.ToString(), f, b, x - 30, y - 30);
        }

        void drawLines()
        {
            Graphics g = Graphics.FromImage(bmpGraph);
            Pen p = new Pen(Color.BlueViolet, 1);

            Vertex v_i;

            for (int i=0; i<graph.VertexCount; i++) {
                v_i = graph.getVertexAt(i);

                for (int j=0; j<v_i.EdgesCount; j++)
                    g.DrawLine(p, v_i.Position, v_i.getDestinationAt(j).Position);
            }

        }

        void drawGraph()
        {
            drawLines();

            // dibujar circulos sobre las lineas
            for (int i=0; i<circleList.Count; i++)
                drawCircle(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].R, bmpGraph, Color.Black, 10);

            // dibujar IDs sobre los circulos
            for (int i=0; i<circleList.Count; i++)
                drawID(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].ID);

            pictureBox.Refresh();
        }


        void fillTree()
        {
            treeView.Nodes.Clear();

            Vertex v_i;

            for (int i=0; i<graph.VertexCount; i++) {
                v_i = graph.getVertexAt(i);
                TreeNode node = new TreeNode(v_i.ToString());

                for (int j=0; j<v_i.EdgesCount; j++) {
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
            comboBoxShortestPath.Items.Clear();

            Vertex v_i;

            for(int i=0; i<graph.VertexCount; i++) {
                v_i = graph.getVertexAt(i);

                comboBoxAgentSelection.Items.Add(v_i);
                comboBoxObjetiveSelection.Items.Add(v_i);
                comboBoxShortestPath.Items.Add(v_i);
            }
        }


        void moveAgent(List<Point> path)
        {
            Graphics g = Graphics.FromImage(bmpAnimation);

            for(int i=0; i<path.Count; i+=8) { // El incremento es la velocidad a la que se mueve el agente
                g.Clear(Color.Transparent);
                drawCircle(path[i].X, path[i].Y, 6, bmpAnimation, Color.CornflowerBlue, 4);
                pictureBox.Refresh();
            }
        }

        void simulation()
        {
            
        }


        List<Vertex> breadthVertices(MyTree breadthTree)
        {
            List<Vertex> vertices = new List<Vertex>();

            MyTreeNode aux = breadthTree.find(objetive.ObjetiveVertex);

            while(aux != null) {
                vertices.Add(aux.Data);
                aux = aux.Father;
            }

            return vertices;
        }

        
    }
}