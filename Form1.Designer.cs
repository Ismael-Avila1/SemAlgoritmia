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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxAgentSelection = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labelAgent = new System.Windows.Forms.Label();
            this.labelObjetive = new System.Windows.Forms.Label();
            this.buttonSetAgentAndObjetive = new System.Windows.Forms.Button();
            this.buttonRunSimulation = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView.Location = new System.Drawing.Point(977, 255);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(250, 257);
            this.treeView.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSetAgentAndObjetive);
            this.groupBox1.Controls.Add(this.labelObjetive);
            this.groupBox1.Controls.Add(this.labelAgent);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBoxAgentSelection);
            this.groupBox1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 212);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agentes y Objetivos";
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
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 160);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(170, 28);
            this.comboBox2.TabIndex = 1;
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
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(914, 547);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(356, 184);
            this.listBoxLog.TabIndex = 6;
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonCreateGraph);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox;
        private Button buttonLoadImage;
        private Button buttonCreateGraph;
        private TreeView treeView;
        private GroupBox groupBox1;
        private Button buttonSetAgentAndObjetive;
        private Label labelObjetive;
        private Label labelAgent;
        private ComboBox comboBox2;
        private ComboBox comboBoxAgentSelection;
        private Button buttonRunSimulation;
        private ListBox listBoxLog;
        private OpenFileDialog openFileDialog;
    }
}