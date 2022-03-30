namespace SemAlgoritmia
{
    public partial class Form1 : Form
    {
        Bitmap bmpImage;
        Bitmap bmpGraph;
        Bitmap bmpAnimation;

        Agent agent;
        Objetive objetive;

        List<Circle> circleList;
        Graph graph;

        MyTree depthTree;
        MyTree breadthTree;

        public Form1()
        {
            InitializeComponent();

            circleList = new List<Circle>();
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
            buttonRunSimulation.Visible = false;
        }

        private void buttonCreateGraph_Click(object sender, EventArgs e)
        {
            circleList.Clear();

            findCircles();

            for (int i = 0; i < circleList.Count; i++)
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
            buttonRunSimulation.Visible = true;

            buttonRunSimulation.Enabled = false;
        }

        private void buttonSetAgentAndObjetive_Click(object sender, EventArgs e)
        {
            if (comboBoxAgentSelection.SelectedItem == null || comboBoxObjetiveSelection.SelectedItem == null) {
                MessageBox.Show("Selecciona un vertice para añadir al Agente y al Objetivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonRunSimulation.Enabled = false;
                return;
            }

            createAgentAndObjetive();

            drawCircle(graph.getVertexAt(agent.VertexIndex).Position.X, graph.getVertexAt(agent.VertexIndex).Position.Y, 8, bmpGraph, Color.CornflowerBlue, 4);
            drawCircle(graph.getVertexAt(objetive.VertexIndex).Position.X, graph.getVertexAt(objetive.VertexIndex).Position.Y, 3, bmpGraph, Color.LightGoldenrodYellow, 4);

            pictureBox.Refresh();

            buttonRunSimulation.Enabled = true;
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
                drawCircle(circleList[i].Center.X, circleList[i].Center.Y, circleList[i].R, bmpGraph, Color.Black, 10);

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


        void createAgentAndObjetive()
        {
            drawGraph();

            agent = new Agent(comboBoxAgentSelection.SelectedIndex);
            objetive = new Objetive(comboBoxObjetiveSelection.SelectedIndex);
        }

        void moveAgent(List<Point> path)
        {
            Graphics g = Graphics.FromImage(bmpAnimation);

            for (int i = 0; i < path.Count; i += 8) { // El incremento es la velocidad a la que se mueve el agente
                g.Clear(Color.Transparent);
                drawCircle(path[i].X, path[i].Y, 6, bmpAnimation, Color.CornflowerBlue, 4);
                pictureBox.Refresh();
            }
        }

        void simulation()
        {
            drawGraph();
            drawCircle(graph.getVertexAt(objetive.VertexIndex).Position.X, graph.getVertexAt(objetive.VertexIndex).Position.Y, 3, bmpGraph, Color.LightGoldenrodYellow, 4);


            DFS();
            List<Vertex> depthVertices = depthTree.inorder();

            for(int i = 0; i < depthVertices.Count; i++) {
                if(depthVertices[i].Id == objetive.VertexIndex + 1) {
                    MessageBox.Show("Objetivo alcanzado", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }

                moveAgent(depthVertices[i].getEdgePath(depthVertices[i].findDestinationVertexIndex(graph.getVertexAt(depthVertices[i].Id - 1), graph.getVertexAt(depthVertices[i + 1].Id - 1))));
            }

            BFS();
            // se recorre el arbol en anchura para obtener la mejor secuencia para llegar al objetivo
            List<Vertex> bestSecuence = breadthVertices();

            Graphics g = Graphics.FromImage(bmpAnimation);
            Pen p = new Pen(Color.LimeGreen, 5);

            for (int j=0; j<bestSecuence.Count-1; j++) {
                g.DrawLine(p, bestSecuence[j].Position, bestSecuence[j + 1].Position);
            }
            pictureBox.Refresh();
            MessageBox.Show("La línea verde representa la menor cantidad de pasos para llegar al objetivo", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void DFS()
        {
            agent.VisitedVertices.Clear();

            Vertex v_inicial = graph.getVertexAt(agent.VertexIndex);
            Vertex v_o = v_inicial;
            Vertex v_obj = graph.getVertexAt(objetive.VertexIndex);

            depthTree = new MyTree(v_inicial);

            bool explore = true;

            //MyTreeNode destinationLeaf;

            DFS(v_o, agent.VisitedVertices, depthTree.Root, explore, v_obj/*, destinationLeaf*/);
        }

        void DFS(Vertex v_o, List<Vertex> visited, MyTreeNode root, bool explore, Vertex v_obj/*, MyTreeNode destinationLeaf*/)
        {
            visited.Add(v_o);

            if(v_o.Id == v_obj.Id) // si ya se llego al objetivo
                explore = false;
                //destinationLeaf = root;

            for(int i=0; i<v_o.EdgesCount; i++) {
                if (!explore)
                    return;

                if(!agent.isVertexVisited(v_o.getDestinationAt(i))) {
                    MyTreeNode child = new MyTreeNode(v_o.getDestinationAt(i), root);
                    root.addChild(child);
                    DFS(v_o.getDestinationAt(i), visited, child, explore, v_obj);
                }
            }

            return;
        }


        void BFS()
        {
            agent.VisitedVertices.Clear();
            
            Vertex v_inicial = graph.getVertexAt(agent.VertexIndex);
            Vertex v_o = v_inicial;
            Vertex v_obj = graph.getVertexAt(objetive.VertexIndex);

            Queue<Vertex> q = new Queue<Vertex>();

            agent.VisitedVertices.Add(v_o);
            q.Enqueue(v_o);

            breadthTree = new MyTree(v_inicial);

            MyTreeNode destinationLeaf = new MyTreeNode();

            bool explore = true;

            BFS(q, agent.VisitedVertices, v_o, breadthTree.Root, v_obj, breadthTree, destinationLeaf);

        }

        void BFS(Queue<Vertex> q, List<Vertex> visited, Vertex v_o, MyTreeNode root, Vertex v_obj, MyTree tree, MyTreeNode destinationLeaf)
        {
            if(q.Count == 0)
                return;

            v_o = q.Dequeue();
            root = tree.find(tree.Root, v_o);

            for(int i=0; i<v_o.EdgesCount; i++) {
                if(!agent.isVertexVisited(v_o.getDestinationAt(i))) {
                    q.Enqueue(v_o.getDestinationAt(i));

                    MyTreeNode child = new MyTreeNode(v_o.getDestinationAt(i), root);
                    root.addChild(child);

                    visited.Add(v_o.getDestinationAt(i));

                    if(v_o.getDestinationAt(i) == v_obj) {
                        destinationLeaf = tree.find(tree.Root, v_o.getDestinationAt(i));
                        q.Clear();
                        return;
                    }
                }
            }

            BFS(q, visited, v_o, root, v_obj, tree, destinationLeaf);
        }

        List<Vertex> breadthVertices()
        {
            List<Vertex> vertices = new List<Vertex>();

            MyTreeNode aux = breadthTree.find(breadthTree.Root, graph.getVertexAt(objetive.VertexIndex));

            while(aux != null) {
                vertices.Add(aux.Data);
                aux = aux.Father;
            }

            return vertices;
        }



    }
}