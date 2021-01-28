namespace ACUDECIDE
{
    partial class voter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.votedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.votetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acudbDataSet1 = new ACUDECIDE.AcudbDataSet1();
            this.registerTableAdapter = new ACUDECIDE.AcudbDataSet1TableAdapters.RegisterTableAdapter();
            this.acudbDataSet6 = new ACUDECIDE.AcudbDataSet6();
            this.registerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.registerTableAdapter1 = new ACUDECIDE.AcudbDataSet6TableAdapters.RegisterTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acudbDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acudbDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fnameDataGridViewTextBoxColumn,
            this.lnameDataGridViewTextBoxColumn,
            this.matricDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.deptDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.voteDataGridViewTextBoxColumn,
            this.votedateDataGridViewTextBoxColumn,
            this.votetimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.registerBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1050, 600);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "S/N";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fnameDataGridViewTextBoxColumn
            // 
            this.fnameDataGridViewTextBoxColumn.DataPropertyName = "fname";
            this.fnameDataGridViewTextBoxColumn.HeaderText = "FIRST NAME";
            this.fnameDataGridViewTextBoxColumn.Name = "fnameDataGridViewTextBoxColumn";
            // 
            // lnameDataGridViewTextBoxColumn
            // 
            this.lnameDataGridViewTextBoxColumn.DataPropertyName = "lname";
            this.lnameDataGridViewTextBoxColumn.HeaderText = "LASTNAME";
            this.lnameDataGridViewTextBoxColumn.Name = "lnameDataGridViewTextBoxColumn";
            // 
            // matricDataGridViewTextBoxColumn
            // 
            this.matricDataGridViewTextBoxColumn.DataPropertyName = "matric";
            this.matricDataGridViewTextBoxColumn.HeaderText = "MATRIC No.";
            this.matricDataGridViewTextBoxColumn.Name = "matricDataGridViewTextBoxColumn";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "GENDER";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "LEVEL";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            // 
            // deptDataGridViewTextBoxColumn
            // 
            this.deptDataGridViewTextBoxColumn.DataPropertyName = "dept";
            this.deptDataGridViewTextBoxColumn.HeaderText = "DEPARTMENT";
            this.deptDataGridViewTextBoxColumn.Name = "deptDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "DATE";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // voteDataGridViewTextBoxColumn
            // 
            this.voteDataGridViewTextBoxColumn.DataPropertyName = "vote";
            this.voteDataGridViewTextBoxColumn.HeaderText = "VOTED ?";
            this.voteDataGridViewTextBoxColumn.Name = "voteDataGridViewTextBoxColumn";
            // 
            // votedateDataGridViewTextBoxColumn
            // 
            this.votedateDataGridViewTextBoxColumn.DataPropertyName = "votedate";
            this.votedateDataGridViewTextBoxColumn.HeaderText = "VOTE DATE";
            this.votedateDataGridViewTextBoxColumn.Name = "votedateDataGridViewTextBoxColumn";
            // 
            // votetimeDataGridViewTextBoxColumn
            // 
            this.votetimeDataGridViewTextBoxColumn.DataPropertyName = "votetime";
            this.votetimeDataGridViewTextBoxColumn.HeaderText = "VOTE TIME";
            this.votetimeDataGridViewTextBoxColumn.Name = "votetimeDataGridViewTextBoxColumn";
            // 
            // registerBindingSource
            // 
            this.registerBindingSource.DataMember = "Register";
            this.registerBindingSource.DataSource = this.acudbDataSet1;
            // 
            // acudbDataSet1
            // 
            this.acudbDataSet1.DataSetName = "AcudbDataSet1";
            this.acudbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registerTableAdapter
            // 
            this.registerTableAdapter.ClearBeforeFill = true;
            // 
            // acudbDataSet6
            // 
            this.acudbDataSet6.DataSetName = "AcudbDataSet6";
            this.acudbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registerBindingSource1
            // 
            this.registerBindingSource1.DataMember = "Register";
            this.registerBindingSource1.DataSource = this.acudbDataSet6;
            // 
            // registerTableAdapter1
            // 
            this.registerTableAdapter1.ClearBeforeFill = true;
            // 
            // voter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "voter";
            this.Text = "voter";
            this.Load += new System.EventHandler(this.voter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acudbDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acudbDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private AcudbDataSet1 acudbDataSet1;
        private System.Windows.Forms.BindingSource registerBindingSource;
        private AcudbDataSet1TableAdapters.RegisterTableAdapter registerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn votedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn votetimeDataGridViewTextBoxColumn;
        private AcudbDataSet6 acudbDataSet6;
        private System.Windows.Forms.BindingSource registerBindingSource1;
        private AcudbDataSet6TableAdapters.RegisterTableAdapter registerTableAdapter1;
    }
}