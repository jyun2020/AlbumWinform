﻿namespace adonet._4.Disconnected
{
    partial class FrmLookUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLookUP));
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label productNameLabel;
            System.Windows.Forms.Label supplierIDLabel;
            System.Windows.Forms.Label categoryIDLabel;
            System.Windows.Forms.Label quantityPerUnitLabel;
            System.Windows.Forms.Label unitPriceLabel;
            System.Windows.Forms.Label unitsInStockLabel;
            System.Windows.Forms.Label unitsOnOrderLabel;
            System.Windows.Forms.Label reorderLevelLabel;
            System.Windows.Forms.Label discontinuedLabel;
            this.Label4 = new System.Windows.Forms.Label();
            this.northwindDataset = new adonet.NorthwindDataset();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new adonet.NorthwindDatasetTableAdapters.ProductsTableAdapter();
            this.tableAdapterManager = new adonet.NorthwindDatasetTableAdapters.TableAdapterManager();
            this.productsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.productsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierIDTextBox = new System.Windows.Forms.TextBox();
            this.categoryIDTextBox = new System.Windows.Forms.TextBox();
            this.quantityPerUnitTextBox = new System.Windows.Forms.TextBox();
            this.unitPriceTextBox = new System.Windows.Forms.TextBox();
            this.unitsInStockTextBox = new System.Windows.Forms.TextBox();
            this.unitsOnOrderTextBox = new System.Windows.Forms.TextBox();
            this.reorderLevelTextBox = new System.Windows.Forms.TextBox();
            this.discontinuedCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.categoriesTableAdapter1 = new adonet.NorthwindDatasetTableAdapters.CategoriesTableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            productIDLabel = new System.Windows.Forms.Label();
            productNameLabel = new System.Windows.Forms.Label();
            supplierIDLabel = new System.Windows.Forms.Label();
            categoryIDLabel = new System.Windows.Forms.Label();
            quantityPerUnitLabel = new System.Windows.Forms.Label();
            unitPriceLabel = new System.Windows.Forms.Label();
            unitsInStockLabel = new System.Windows.Forms.Label();
            unitsOnOrderLabel = new System.Windows.Forms.Label();
            reorderLevelLabel = new System.Windows.Forms.Label();
            discontinuedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingNavigator)).BeginInit();
            this.productsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.Red;
            this.Label4.Location = new System.Drawing.Point(608, 42);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(180, 90);
            this.Label4.TabIndex = 115;
            this.Label4.Text = "LookUp Control 查閱資料表\r\n\r\nDataSource\r\nDisplayMember\r\nValueMember\r\nDataBindings (Sel" +
    "ectedValue)\r\n";
            // 
            // northwindDataset
            // 
            this.northwindDataset.DataSetName = "NorthwindDataset";
            this.northwindDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.northwindDataset;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoriesTableAdapter = this.categoriesTableAdapter1;
            this.tableAdapterManager.CustomersTableAdapter = null;
            this.tableAdapterManager.ProductsTableAdapter = this.productsTableAdapter;
            this.tableAdapterManager.UpdateOrder = adonet.NorthwindDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // productsBindingNavigator
            // 
            this.productsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.productsBindingNavigator.BindingSource = this.productsBindingSource;
            this.productsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.productsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.productsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.productsBindingNavigatorSaveItem});
            this.productsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.productsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.productsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.productsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.productsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.productsBindingNavigator.Name = "productsBindingNavigator";
            this.productsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productsBindingNavigator.Size = new System.Drawing.Size(808, 27);
            this.productsBindingNavigator.TabIndex = 116;
            this.productsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 19);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // productsBindingNavigatorSaveItem
            // 
            this.productsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productsBindingNavigatorSaveItem.Image")));
            this.productsBindingNavigatorSaveItem.Name = "productsBindingNavigatorSaveItem";
            this.productsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.productsBindingNavigatorSaveItem.Text = "儲存資料";
            this.productsBindingNavigatorSaveItem.Click += new System.EventHandler(this.productsBindingNavigatorSaveItem_Click);
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize = true;
            productIDLabel.Location = new System.Drawing.Point(25, 64);
            productIDLabel.Name = "productIDLabel";
            productIDLabel.Size = new System.Drawing.Size(74, 15);
            productIDLabel.TabIndex = 116;
            productIDLabel.Text = "Product ID:";
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(143, 61);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.Size = new System.Drawing.Size(104, 25);
            this.productIDTextBox.TabIndex = 117;
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Location = new System.Drawing.Point(25, 95);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new System.Drawing.Size(92, 15);
            productNameLabel.TabIndex = 118;
            productNameLabel.Text = "Product Name:";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "ProductName", true));
            this.productNameTextBox.Location = new System.Drawing.Point(143, 92);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(104, 25);
            this.productNameTextBox.TabIndex = 119;
            // 
            // supplierIDLabel
            // 
            supplierIDLabel.AutoSize = true;
            supplierIDLabel.Location = new System.Drawing.Point(25, 126);
            supplierIDLabel.Name = "supplierIDLabel";
            supplierIDLabel.Size = new System.Drawing.Size(78, 15);
            supplierIDLabel.TabIndex = 120;
            supplierIDLabel.Text = "Supplier ID:";
            // 
            // supplierIDTextBox
            // 
            this.supplierIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "SupplierID", true));
            this.supplierIDTextBox.Location = new System.Drawing.Point(143, 123);
            this.supplierIDTextBox.Name = "supplierIDTextBox";
            this.supplierIDTextBox.Size = new System.Drawing.Size(104, 25);
            this.supplierIDTextBox.TabIndex = 121;
            // 
            // categoryIDLabel
            // 
            categoryIDLabel.AutoSize = true;
            categoryIDLabel.Location = new System.Drawing.Point(25, 157);
            categoryIDLabel.Name = "categoryIDLabel";
            categoryIDLabel.Size = new System.Drawing.Size(81, 15);
            categoryIDLabel.TabIndex = 122;
            categoryIDLabel.Text = "Category ID:";
            // 
            // categoryIDTextBox
            // 
            this.categoryIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "CategoryID", true));
            this.categoryIDTextBox.Location = new System.Drawing.Point(143, 154);
            this.categoryIDTextBox.Name = "categoryIDTextBox";
            this.categoryIDTextBox.Size = new System.Drawing.Size(104, 25);
            this.categoryIDTextBox.TabIndex = 123;
            // 
            // quantityPerUnitLabel
            // 
            quantityPerUnitLabel.AutoSize = true;
            quantityPerUnitLabel.Location = new System.Drawing.Point(25, 188);
            quantityPerUnitLabel.Name = "quantityPerUnitLabel";
            quantityPerUnitLabel.Size = new System.Drawing.Size(112, 15);
            quantityPerUnitLabel.TabIndex = 124;
            quantityPerUnitLabel.Text = "Quantity Per Unit:";
            // 
            // quantityPerUnitTextBox
            // 
            this.quantityPerUnitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "QuantityPerUnit", true));
            this.quantityPerUnitTextBox.Location = new System.Drawing.Point(143, 185);
            this.quantityPerUnitTextBox.Name = "quantityPerUnitTextBox";
            this.quantityPerUnitTextBox.Size = new System.Drawing.Size(104, 25);
            this.quantityPerUnitTextBox.TabIndex = 125;
            // 
            // unitPriceLabel
            // 
            unitPriceLabel.AutoSize = true;
            unitPriceLabel.Location = new System.Drawing.Point(25, 219);
            unitPriceLabel.Name = "unitPriceLabel";
            unitPriceLabel.Size = new System.Drawing.Size(69, 15);
            unitPriceLabel.TabIndex = 126;
            unitPriceLabel.Text = "Unit Price:";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "UnitPrice", true));
            this.unitPriceTextBox.Location = new System.Drawing.Point(143, 216);
            this.unitPriceTextBox.Name = "unitPriceTextBox";
            this.unitPriceTextBox.Size = new System.Drawing.Size(104, 25);
            this.unitPriceTextBox.TabIndex = 127;
            // 
            // unitsInStockLabel
            // 
            unitsInStockLabel.AutoSize = true;
            unitsInStockLabel.Location = new System.Drawing.Point(25, 250);
            unitsInStockLabel.Name = "unitsInStockLabel";
            unitsInStockLabel.Size = new System.Drawing.Size(93, 15);
            unitsInStockLabel.TabIndex = 128;
            unitsInStockLabel.Text = "Units In Stock:";
            // 
            // unitsInStockTextBox
            // 
            this.unitsInStockTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "UnitsInStock", true));
            this.unitsInStockTextBox.Location = new System.Drawing.Point(143, 247);
            this.unitsInStockTextBox.Name = "unitsInStockTextBox";
            this.unitsInStockTextBox.Size = new System.Drawing.Size(104, 25);
            this.unitsInStockTextBox.TabIndex = 129;
            // 
            // unitsOnOrderLabel
            // 
            unitsOnOrderLabel.AutoSize = true;
            unitsOnOrderLabel.Location = new System.Drawing.Point(25, 281);
            unitsOnOrderLabel.Name = "unitsOnOrderLabel";
            unitsOnOrderLabel.Size = new System.Drawing.Size(99, 15);
            unitsOnOrderLabel.TabIndex = 130;
            unitsOnOrderLabel.Text = "Units On Order:";
            // 
            // unitsOnOrderTextBox
            // 
            this.unitsOnOrderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "UnitsOnOrder", true));
            this.unitsOnOrderTextBox.Location = new System.Drawing.Point(143, 278);
            this.unitsOnOrderTextBox.Name = "unitsOnOrderTextBox";
            this.unitsOnOrderTextBox.Size = new System.Drawing.Size(104, 25);
            this.unitsOnOrderTextBox.TabIndex = 131;
            // 
            // reorderLevelLabel
            // 
            reorderLevelLabel.AutoSize = true;
            reorderLevelLabel.Location = new System.Drawing.Point(25, 312);
            reorderLevelLabel.Name = "reorderLevelLabel";
            reorderLevelLabel.Size = new System.Drawing.Size(92, 15);
            reorderLevelLabel.TabIndex = 132;
            reorderLevelLabel.Text = "Reorder Level:";
            // 
            // reorderLevelTextBox
            // 
            this.reorderLevelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "ReorderLevel", true));
            this.reorderLevelTextBox.Location = new System.Drawing.Point(143, 309);
            this.reorderLevelTextBox.Name = "reorderLevelTextBox";
            this.reorderLevelTextBox.Size = new System.Drawing.Size(104, 25);
            this.reorderLevelTextBox.TabIndex = 133;
            // 
            // discontinuedLabel
            // 
            discontinuedLabel.AutoSize = true;
            discontinuedLabel.Location = new System.Drawing.Point(25, 345);
            discontinuedLabel.Name = "discontinuedLabel";
            discontinuedLabel.Size = new System.Drawing.Size(85, 15);
            discontinuedLabel.TabIndex = 134;
            discontinuedLabel.Text = "Discontinued:";
            // 
            // discontinuedCheckBox
            // 
            this.discontinuedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.productsBindingSource, "Discontinued", true));
            this.discontinuedCheckBox.Location = new System.Drawing.Point(143, 340);
            this.discontinuedCheckBox.Name = "discontinuedCheckBox";
            this.discontinuedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.discontinuedCheckBox.TabIndex = 135;
            this.discontinuedCheckBox.Text = "checkBox1";
            this.discontinuedCheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "CategoryID", true));
            this.comboBox1.DataSource = this.northwindDataset;
            this.comboBox1.DisplayMember = "Categories.CategoryName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(288, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 136;
            this.comboBox1.ValueMember = "Products.CategoryID";
            // 
            // categoriesTableAdapter1
            // 
            this.categoriesTableAdapter1.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.northwindDataset;
            this.listBox1.DisplayMember = "Categories.CategoryName";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(475, 170);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 139);
            this.listBox1.TabIndex = 137;
            // 
            // FrmLookUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 579);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(productIDLabel);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(productNameLabel);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(supplierIDLabel);
            this.Controls.Add(this.supplierIDTextBox);
            this.Controls.Add(categoryIDLabel);
            this.Controls.Add(this.categoryIDTextBox);
            this.Controls.Add(quantityPerUnitLabel);
            this.Controls.Add(this.quantityPerUnitTextBox);
            this.Controls.Add(unitPriceLabel);
            this.Controls.Add(this.unitPriceTextBox);
            this.Controls.Add(unitsInStockLabel);
            this.Controls.Add(this.unitsInStockTextBox);
            this.Controls.Add(unitsOnOrderLabel);
            this.Controls.Add(this.unitsOnOrderTextBox);
            this.Controls.Add(reorderLevelLabel);
            this.Controls.Add(this.reorderLevelTextBox);
            this.Controls.Add(discontinuedLabel);
            this.Controls.Add(this.discontinuedCheckBox);
            this.Controls.Add(this.productsBindingNavigator);
            this.Controls.Add(this.Label4);
            this.Name = "FrmLookUP";
            this.Text = "FrmLookUP";
            this.Load += new System.EventHandler(this.FrmLookUP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingNavigator)).EndInit();
            this.productsBindingNavigator.ResumeLayout(false);
            this.productsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        private NorthwindDataset northwindDataset;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private NorthwindDatasetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private NorthwindDatasetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator productsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton productsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox supplierIDTextBox;
        private System.Windows.Forms.TextBox categoryIDTextBox;
        private System.Windows.Forms.TextBox quantityPerUnitTextBox;
        private System.Windows.Forms.TextBox unitPriceTextBox;
        private System.Windows.Forms.TextBox unitsInStockTextBox;
        private System.Windows.Forms.TextBox unitsOnOrderTextBox;
        private System.Windows.Forms.TextBox reorderLevelTextBox;
        private System.Windows.Forms.CheckBox discontinuedCheckBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private NorthwindDatasetTableAdapters.CategoriesTableAdapter categoriesTableAdapter1;
        private System.Windows.Forms.ListBox listBox1;
    }
}