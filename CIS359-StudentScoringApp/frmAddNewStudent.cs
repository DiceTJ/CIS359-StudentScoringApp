﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS359_StudentScoringApp
{
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        List<int> scoreList = new List<int>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidScore())
            {
                int score = Convert.ToInt32(txtScore.Text);
                scoreList.Add(score);
                DisplayScores();
                txtScore.Focus();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            scoresList.Clear();
            lblScores.Text = "";
            txtScore.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsValidName())
            {
                string studentScores = txtName.Text;
                foreach (int score in scoreList)
                {
                    studentScores += $"|{score}";
                }
                Tag = studentScores;
                DialogResult = DialogResult.OK;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisplayScores()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int score in scoreList) 
            {
                sb.Append($"{score} ");
            }
            lblScores.Text = sb.ToString();
        }

        private bool IsValidScore()
        {
            bool success = true;

            StringBuilder sb = new StringBuilder();
            sb.Append(IsPresent(txtScore.Text, "Score"));
            sb.Append(IsInt32(txtScore.Text, "Score"));
            sb.Append(IsWithinRange(txtScore.Text, "Score", 0, 100));
            string errorMsg = sb.ToString();

            if (!String.IsNullOrEmpty(errorMsg))
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }

            return success;
        }

        private bool IsValidName()
        {
            bool success = true;
            string errorMsg = IsPresent(txtName.Text, "Name");
            if (!String.IsNullOrEmpty(errorMsg))
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }
            return success;

        }
        private string IsPresent(string value, string name)
        {
            string errorMsg = "";
            if (String.IsNullOrEmpty(value)) 
            {
                errorMsg = $"{name} is a required field.\n";
            }
            return errorMsg;
        }

        private string IsInt32(string value, string name)
        {
            string errorMsg = "";
            if (!Int32.TryParse(value, out _))
            {
                errorMsg = $"{name} is a required field.\n";
            }
            return errorMsg;
        }

        private string IsWithinRange(string value, string name, decimal min, decimal max)
        {
            string errorMsg = "";

            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max) 
                {
                    errorMsg = $"{name} must be between {min} and {max}.\n";
                }
            }
            return errorMsg;
        }

        private void frmAddNewStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
