namespace SemAlgoritmia
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonCreateGraph = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonSetAgentAndObjetive = new System.Windows.Forms.Button();
            this.labelObjetive = new System.Windows.Forms.Label();
            this.labelAgent = new System.Windows.Forms.Label();
            this.comboBoxObjetiveSelection = new System.Windows.Forms.ComboBox();
            this.comboBoxAgentSelection = new System.Windows.Forms.ComboBox();
            this.buttonRunSimulation = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(900, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(128)))));
            this.buttonLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadImage.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.buttonLoadImage.Location = new System.Drawing.Point(977, 12);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(250, 70);
            this.buttonLoadImage.TabIndex = 1;
            this.buttonLoadImage.Text = "Cargar Imagen";
            this.buttonLoadImage.UseVisualStyleBackColor = false;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonCreateGraph
            // 
            this.buttonCreateGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(128)))));
            this.buttonCreateGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateGraph.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateGraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.buttonCreateGraph.Location = new System.Drawing.Point(977, 159);
            this.buttonCreateGraph.Name = "buttonCreateGraph";
            this.buttonCreateGraph.Size = new System.Drawing.Size(250, 70);
            this.buttonCreateGraph.TabIndex = 2;
            this.buttonCreateGraph.Text = "Generar Grafo";
            this.buttonCreateGraph.UseVisualStyleBackColor = false;
            this.buttonCreateGraph.Visible = false;
            this.buttonCreateGraph.Click += new System.EventHandler(this.buttonCreateGraph_Click);
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView.Location = new System.Drawing.Point(977, 255);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(250, 257);
            this.treeView.TabIndex = 3;
            this.treeView.Visible = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonSetAgentAndObjetive);
            this.groupBox.Controls.Add(this.labelObjetive);
            this.groupBox.Controls.Add(this.labelAgent);
            this.groupBox.Controls.Add(this.comboBoxObjetiveSelection);
            this.groupBox.Controls.Add(this.comboBoxAgentSelection);
            this.groupBox.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.groupBox.Location = new System.Drawing.Point(12, 529);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(617, 212);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Agentes y Objetivos";
            this.groupBox.Visible = false;
            // 
            // buttonSetAgentAndObjetive
            // 
            this.buttonSetAgentAndObjetive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(128)))));
            this.buttonSetAgentAndObjetive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSetAgentAndObjetive.Font = new System.Drawing.Font("Open Sans", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSetAgentAndObjetive.Location = new System.Drawing.Point(399, 67);
            this.buttonSetAgentAndObjetive.Name = "buttonSetAgentAndObjetive";
            this.buttonSetAgentAndObjetive.Size = new System.Drawing.Size(190, 80);
            this.buttonSetAgentAndObjetive.TabIndex = 4;
            this.buttonSetAgentAndObjetive.Text = "Establecer Agente y Objetivo";
            this.buttonSetAgentAndObjetive.UseVisualStyleBackColor = false;
            this.buttonSetAgentAndObjetive.Click += new System.EventHandler(this.buttonSetAgentAndObjetive_Click);
            // 
            // labelObjetive
            // 
            this.labelObjetive.AutoSize = true;
            this.labelObjetive.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelObjetive.Location = new System.Drawing.Point(6, 124);
            this.labelObjetive.Name = "labelObjetive";
            this.labelObjetive.Size = new System.Drawing.Size(348, 23);
            this.labelObjetive.TabIndex = 3;
            this.labelObjetive.Text = "Selecciona el vertice para añadir el Objetivo";
            // 
            // labelAgent
            // 
            this.labelAgent.AutoSize = true;
            this.labelAgent.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAgent.Location = new System.Drawing.Point(6, 38);
            this.labelAgent.Name = "labelAgent";
            this.labelAgent.Size = new System.Drawing.Size(338, 23);
            this.labelAgent.TabIndex = 2;
            this.labelAgent.Text = "Selecciona el vertice para añadir el Agente";
            // 
            // comboBoxObjetiveSelection
            // 
            this.comboBoxObjetiveSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjetiveSelection.FormattingEnabled = true;
            this.comboBoxObjetiveSelection.Location = new System.Drawing.Point(6, 160);
            this.comboBoxObjetiveSelection.Name = "comboBoxObjetiveSelection";
            this.comboBoxObjetiveSelection.Size = new System.Drawing.Size(170, 28);
            this.comboBoxObjetiveSelection.TabIndex = 1;
            // 
            // comboBoxAgentSelection
            // 
            this.comboBoxAgentSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAgentSelection.FormattingEnabled = true;
            this.comboBoxAgentSelection.Location = new System.Drawing.Point(6, 64);
            this.comboBoxAgentSelection.Name = "comboBoxAgentSelection";
            this.comboBoxAgentSelection.Size = new System.Drawing.Size(170, 28);
            this.comboBoxAgentSelection.TabIndex = 0;
            // 
            // buttonRunSimulation
            // 
            this.buttonRunSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(108)))), ((int)(((byte)(77)))));
            this.buttonRunSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunSimulation.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRunSimulation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.buttonRunSimulation.Location = new System.Drawing.Point(688, 594);
            this.buttonRunSimulation.Name = "buttonRunSimulation";
            this.buttonRunSimulation.Size = new System.Drawing.Size(190, 80);
            this.buttonRunSimulation.TabIndex = 5;
            this.buttonRunSimulation.Text = "Iniciar Simulación";
            this.buttonRunSimulation.UseVisualStyleBackColor = false;
            this.buttonRunSimulation.Visible = false;
            this.buttonRunSimulation.Click += new System.EventHandler(this.buttonRunSimulation_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(914, 567);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(356, 164);
            this.listBoxLog.TabIndex = 6;
            this.listBoxLog.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonRunSimulation);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonCreateGraph);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox;
        private Button buttonLoadImage;
        private Button buttonCreateGraph;
        private TreeView treeView;
        private GroupBox groupBox;
        private Button buttonSetAgentAndObjetive;
        private Label labelObjetive;
        private Label labelAgent;
        private ComboBox comboBoxObjetiveSelection;
        private ComboBox comboBoxAgentSelection;
        private Button buttonRunSimulation;
        private ListBox listBoxLog;
        private OpenFileDialog openFileDialog;
    }
}