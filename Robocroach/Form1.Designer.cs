namespace Robocroach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelField = new System.Windows.Forms.Panel();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.Algorithm = new System.Windows.Forms.ListBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonStep = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timerAlgorithm = new System.Windows.Forms.Timer(this.components);
            this.panelGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelField
            // 
            this.panelField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelField.Location = new System.Drawing.Point(13, 13);
            this.panelField.Name = "panelField";
            this.panelField.Size = new System.Drawing.Size(618, 575);
            this.panelField.TabIndex = 0;
            this.panelField.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelField_DragDrop);
            this.panelField.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelField_DragEnter);
            // 
            // panelGroup
            // 
            this.panelGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGroup.Controls.Add(this.buttonClear);
            this.panelGroup.Controls.Add(this.buttonRun);
            this.panelGroup.Controls.Add(this.buttonNew);
            this.panelGroup.Controls.Add(this.buttonStep);
            this.panelGroup.Controls.Add(this.buttonRight);
            this.panelGroup.Controls.Add(this.buttonLeft);
            this.panelGroup.Controls.Add(this.buttonDown);
            this.panelGroup.Controls.Add(this.buttonUp);
            this.panelGroup.Location = new System.Drawing.Point(637, 13);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(200, 575);
            this.panelGroup.TabIndex = 1;
            // 
            // Algorithm
            // 
            this.Algorithm.FormattingEnabled = true;
            this.Algorithm.Location = new System.Drawing.Point(844, 13);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(194, 576);
            this.Algorithm.TabIndex = 2;
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(37, 29);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(124, 34);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(37, 69);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(124, 34);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(37, 109);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(124, 34);
            this.buttonLeft.TabIndex = 2;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(37, 149);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(124, 34);
            this.buttonRight.TabIndex = 3;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Location = new System.Drawing.Point(37, 189);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(124, 34);
            this.buttonStep.TabIndex = 4;
            this.buttonStep.Text = "Step";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(37, 443);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(124, 34);
            this.buttonNew.TabIndex = 5;
            this.buttonNew.Text = "New Hero";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(37, 483);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(124, 34);
            this.buttonRun.TabIndex = 6;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(37, 523);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(124, 34);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timerAlgorithm
            // 
            this.timerAlgorithm.Interval = 1000;
            this.timerAlgorithm.Tick += new System.EventHandler(this.timerAlgorithm_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.Algorithm);
            this.Controls.Add(this.panelGroup);
            this.Controls.Add(this.panelField);
            this.Name = "Form1";
            this.Text = "Robocroach";
            this.panelGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelField;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.ListBox Algorithm;
        private System.Windows.Forms.Timer timerAlgorithm;
    }
}

